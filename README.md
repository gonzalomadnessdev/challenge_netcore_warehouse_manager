# Warehouse Manager Challenge


You are a new software engineer in a company that develops a SaaS-based warehouse manager. Your task is to implement an ASP.NET Core API that supports warehouse operations.
The API should expose the following methods:

* **GetProducts()** - this method returns all products that are currently stored in the warehouse;
* **SetProductCapacity(productId, capacity)** - this method sets the maximum storage capacity for specified product;
* **ReceiveProduct(productId, qty)** - this method increments the current quantity of a product stored in the warehouse;
* **DispatchProduct** (productId, qty) - this method decrements the current quantity of a product stored in the warehouse.

## Requirements

The requirements are described using the following notation:
* FunctionName()
	- ResponseType
		- Conditions

The API methods should implement the following business logic:
* **GetProducts()**
	- OkObjectResult(IEnumerable<WarehouseEntry>)
		- Return an array of products currently stored in the warehouse. This method should only return products whose quantity is greater than zero. 

* **SetProductCapacity(productId, capacity)**
	- OkResult
		- Provided data is correct
	- BadRequestObjectResult(Not PositiveQuantityMessage)
		- Provided capacity of product is less than or equal to zero.
	- BadRequestObjectResult(QuantityTooLowMessage)
		- Provided capacity of product is lower than the quantity currently stored in the warehouse

* **ReceiveProduct(productId, qty)**

	- OkResult
		 -Provided data is correct.

	- BadRequestObjectResult(NotPositiveQuantityMessage)
		- Provided quantity of product is less than or equal to zero.

	- BadRequestObjectResult(QuantityTooHighMessage)
		- The sum of the currently stored quantity and the provided quantity is greater than the current capacity. 
		
* **DispatchProduct(productId, qty)**

	- OkResult
		 - Provided data is correct

	- BadRequestObjectResult(NotPositiveQuantityMessage)
		 - Provided quantity of product is less than or equal to zero

	- BadRequestObjectResult(QuantityTooHighMessage)
		- Provided quantity of product is greater than the currently stored quantity


__________________



**Example flow**

Assume starting with an empty warehouse. The execution of the following functions in this particular order will return the following results.

1. SetProductCapacity(1,999) - Warehouse can store up to 999 pieces of product 1; OkResult is returned.
2 ReceiveProduct(1, 1000) -Warehouse cannot receive 1000 pieces of product 1 because it exceeds the previously set capacity, BadRequestObjectResult(QuantityTooHighMessage) is returned.
3. ReceiveProduct(1, 180)
-Warehouse receives 100 pieces of product 1; there are now 100 pieces of product 1 in stock; OkResult
is returned. is returned.
4. DispatchProduct(1, 20) - Warehouse dispatches 20 pieces of product 1; there are now 80 pieces of product 1 in stock, OkResult
5. GetProducts() - Warehouse returns OkObjectResult containing an array of products currently stored in the warehouse. In this case the array will contain one element a WarehouseEntry with ProductId equal to 1 and Quantity equal to 80.
__________________

**Assumptions**

All data should be loaded and saved in IWarehouse Repository. You do not need to implement this repository, it will be provided in the initial code. The repository will return only previously created entries (e.g. if a Capacity Record has never been set, it will not be returned by GetCapacityRecords method; the same applies for the ProductRecord and GetProductRecords methods).
is not returned then the product's Capacity
If CapacityRecord is equal to zero. If ProductRecord is not returned then the product's Quantity is equal to zero.

__________________

Code

Presented below is the code snippet containing the classes and the interface already provided for your
```

public interface IWarehouseRepository
{
    void SetCapacityRecord(int productId, int capacity); IEnumerable<CapacityRecord> GetCapacityRecords();
    IEnumerable<CapacityRecord> GetCapacityRecords(Func<CapacityRecord, bool> filter);
    void SetProductRecord(int productId, int quantity); IEnumerable<ProductRecord> GetProductRecords();
    IEnumerable<ProductRecord> GetProductRecords(Func<ProductRecord, bool> filter);
}

public class CapacityRecord
{
    public int ProductId { get; set; }
    public int Capacity { get; set; }
}

public class ProductRecord
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

}

```

All classes required composing API responses are provided in the following code snippet:

```
// IEnumerable<WarehouseEntry> should be returned by GetProducts method. 
// It can be mapped from ProductRecord
public class WarehouseEntry
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

// NotPositiveQuantity Message should be returned by
// SetProductCapacity, ReceiveProduct and DispatchProduct methods
public class NotPositiveQuantityMessage { 
    public string Message => "A positive quantity was not provided";
}

// QuantityTooLowMessage should be returned by
// SetProductCapacity, ReceiveProduct and DispatchProduct methods
public class QuantityTooLowMessage{
    public string Message => "Too low a quantity was provided";
}

// QuantityTooHighMessage should be returned by
// SetProductCapacity, ReceiveProduct and DispatchProduct methods
public class QuantityTooHighMessage
{ 
    public string Message => "Too high a quantity was provided";
}
```

__________________
