/*using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPController : MonoBehaviour, IStoreListener
{
    public static IAPController instance;
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
        
    public static string Buy_100_Coins = "buy100";
    public static string Buy_200_Coins = "buy200";
    public static string Buy_500_Coins = "buy500";
    public static string Buy_1000_Coins = "buy1000";
    public static string Buy_2000_Coins = "buy2000";
    public static string Buy_4000_Coins = "buy4000";
    public static string Buy_NoAds = "buynoads";
    
    private void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }


    void MakeSingleton()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        
        builder.AddProduct(Buy_100_Coins, ProductType.Consumable);
        builder.AddProduct(Buy_200_Coins, ProductType.Consumable);
        builder.AddProduct(Buy_500_Coins, ProductType.Consumable);
        builder.AddProduct(Buy_1000_Coins, ProductType.Consumable);
        builder.AddProduct(Buy_2000_Coins, ProductType.Consumable);
        builder.AddProduct(Buy_4000_Coins, ProductType.Consumable);
        builder.AddProduct(Buy_NoAds, ProductType.NonConsumable);

        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void Buy100Coins()
    {
        BuyProductID(Buy_100_Coins);
    }

    public void Buy200Coins()
    {
        BuyProductID(Buy_200_Coins);
    }

    public void Buy500Coins()
    {
        BuyProductID(Buy_500_Coins);
    }

    public void Buy1000Coins()
    {
        BuyProductID(Buy_1000_Coins);
    }

    public void Buy2000Coins()
    {
        BuyProductID(Buy_2000_Coins);
    }

    public void Buy4000Coins()
    {
        BuyProductID(Buy_4000_Coins);
    }

    public void BuyNoAds()
    {
        BuyProductID(Buy_NoAds);
    }

    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id , Buy_100_Coins , StringComparison.Ordinal))
        {
            Debug.Log("100 coins received");
            GameController.instance.coins += 100;
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Buy_200_Coins , StringComparison.Ordinal))
        {
            Debug.Log("Buy 200");
            GameController.instance.coins += 200;
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Buy_500_Coins, StringComparison.Ordinal))
        {
            Debug.Log("Buy 500");
            GameController.instance.coins += 500;
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Buy_1000_Coins , StringComparison.Ordinal))
        {
            Debug.Log("Buy 1000");
            GameController.instance.coins += 1000;
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Buy_2000_Coins , StringComparison.Ordinal))
        {
            Debug.Log("Buy 2000");
            GameController.instance.coins += 2000;
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Buy_4000_Coins , StringComparison.Ordinal))
        {
            Debug.Log("Buy 4000");
            GameController.instance.coins += 4000;
        }

        else if (String.Equals(args.purchasedProduct.definition.id, Buy_NoAds, StringComparison.Ordinal))
        {
            Debug.Log("Buy no ads ok");
            GameController.instance.canShowAds = false;
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        GameController.instance.Save();
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
*/