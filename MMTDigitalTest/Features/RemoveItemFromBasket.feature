Feature: RemoveItemFromBasket
	As a subscribed member I can remove product(s) from my cart so that I can check out with a cart only containing the items I want

Scenario: Removing item changes icon to Add to cart
	Given that I am on the inventory page with items in my basket,
	When I click “Remove” on an item I have in my basket,
	Then it will change the “Remove” button to “Add to cart”
	And it will reduce the basket counter icon accordingly

Scenario: Option to remove available for every product
	Given that I have multiple items in my basket,
	When I visit the basket page,
	Then I can see options to remove each product present from the basket

Scenario: Removing item reduces basket count
	Given that I am on the basket page with multiple items in it,
	When I click to “Remove” a product,
	Then it will remove the item from the basket
	And it will reduce the basket counter icon by 1

Scenario: Removing single item removes basket counter
	Given that I am on the basket page with an item in it,
	When I click “Remove” on the product,
	Then it will remove the item from the basket
	And it will remove the basket counter icon
