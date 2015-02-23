Why code defensively?
1. Quality - write unit tests to reduce bugs and problems
2. Comprehensible development - readable and understandible (clean code/refactoring)
3. Predictable - unexpected inputs and response to those inputs (Exception handler)

Clean Code 
- tell good code vs. bad code (code smell))
- refactoring (rewriting bad code to good code)
-- seperate code into seperate classes (without impacting other stuff)

Code Testing
- Unit testing, automated testing
- Building testable code

Validation and Exception Handling

AcmeUI - UI project (MVC/WPF/WCF etc)
	- add reference to Business Layer only!

AcmeBL - Business Layer (class library)
	Entity Classes - Customer, Order, Inventory etc (Class Library)
	Repository Pattern - handle data access, hide details of accessing data in one place, seperate from entity classes

Acme.Common - Generalized Processing
	Common Library - (seperate class library) file handling, email processing, logging

---------
SUMMARY - USE THESE TO CHECK IF YOUR CODE IS GOOD
1. Clear purpose - one function only
2. Good name - clear identifiable name
3. Focused code - only focused on one and only one thing only
4. Short lenght - short
5. Automated code test - unit tests for each method
6. Perdictable code - do I know what it's passing in/out 
	(named parameters)(order params in order most/least important or create a new object if lots of params)

METHOD REFACTORING
1. Define variables close to usage
2. naming (full names)
3. lowerCase - private, UpperCase - public and properties
4. Declare AND initialize on one line
5. If/Else - always use braces and thing Positive NOT if (!this) else
6. Enums - use enums when approperiate. Use (Enum.TryParse) instead of Enum.IsDefined - this uses slow reflection
7. Guard clauses (for classes Customer customer param, add guard clause)
8. Return value - should be known - add OperationResult for methods so that return value is known
---------


OVERVIEW
1. Definitions - description of defensive coding (above)
2. Building clean, testable methods
	- clean, testable, single purpose, good name, focused code on single purpose, short length
	- customer retrieve method -> only 1 purpose (should NOT have customer modifycation code)
	- sample -> button click order -> one method doing everything (creating, ordering, processing payment, emailing etc. -> wrong!)
	- email method can be used for all emailing purposes
	- DRY - don't repeat yourself!
	- use Class Library to store methods, Entities => (Customer, Order, Inventory, Payment)
	- using Repository Pattern - purpose => handle data access, hide details of accessing data in one place, seperate from entity classes


BUILDING ORDER PROCESS : Main -> ProcessOrder(named params) -> Constructor dependencies
-> since order process uses customer, order, inventory etc, use service class (TAKE TWO)
	- leave populating instances in UI because that is data from UI input controls
	- Refactoring -> moving depencies to constructor of ProcessOrder()
	a. TAKE ONE -> take out all code from UI, create a new method in UI (seperation)
	b. TAKE TWO -> create a new class ProcessController.cs => ProcessMethod() => moving dependencies to contructor
	c. TAKE THREE -> PARAMETERS : take out allowSplitOrders, replace with named parameters
	d. TAKE FOUR -> protect order process service class (validation)
	e. TAKE FIVE -> guard clause -> minimize number of params (new object?)

PEDOMETER
- validation - dividing by 0
- FAIL FAST - adding ArgumentExceptions when arguments passed to the method are invalid/null/blank etc
- METHOD OVERLOADING - a method to clean up methods (refactoring params into decimal input)

DESIGN BY CONTRACT
- what does a method expect?
- what does a method guarantee?
- what does the method maintain?

AUTOMATED CODE TESTING 
== Tests -> Windows -> Test Explorer
== Unit tests generator plugin
- Arrange, Act, Assert (tests are self describing)
- Unit tests - goal - isolate each unit of code and verify it behaves as expected
- Not time to do Unit testing?? 
	a. save time - catch bugs
	b. find bugs faster
	c. refactoring
	d. add features - after re-running test you will be able if other features still work etc.
	e. interruptions - can minimize interruptions that test bad possible data entry
- Code first vs. Test first
1. Valid input test, verify output
2. Invalid inputs tests
3. Guard clause tests - test for each guard clause
4. Assumption - define a test for EACH Assumption

RETURNING A VALUE 
- isValid -> should return a value
- CalculatePercent..() -> should not return 0 - can't tell if something went wrong
	customer.ValidateEmail() => should return true/false
	customerRepository.Add(customer) => should return a list of messages if somethign went wrong
- REF keyword - if bool return value is not enough - code smell
- OUT keyword - code smell
- TUPLE - good when returning more values from method (ie. succeeded and message) - clumsy
- OperationResult - BEST (bool, message) => custom object for returning simple method results (Common to all projects)
- WHAT TO RETURN?? DO THIS:
	1. simple value or exceptions => var result = customer.CalculatePercent(this.TextBox1);
	2. multiple values (result and message) => customer.ValidateEmail(); / customerRepository.Add(customer)
	3. NULL => var customer = customerRepository.Find(this.TextBox); => no customer found

RETURNING A NULL
- return NULL if found nothing

GLOBAL EXCEPTION HANDLER
- In start app. GlobalException handler is created. However, should never be used for catching known exceptions/anticipated exceptions

EXCEPTIONS
- don't define exception unless you're going to do something with it (ie. logging). Log exceptions
- handle exceptions locally (within the scope)
- catch specific exceptions
- Do NOT catch them all. ONLY those who we are ANTICIPATING!
	(example: SendEmail (InvalidOperationException => throw (NOT throw ex => doing throw ex looses call stack info)))

