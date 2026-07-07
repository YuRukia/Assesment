Setup Steps
- open cmd in destination folder
- enter 'git clone https://github.com/YuRukia/Assesment'
- enter 'cd Assesment'
- enter 'dotnet build'
- enter 'dotnet test'

Suggested Operation
- dotnet test --settings:Config/chromium.runsettings | To run all tests
- dotnet test --settings:Config/chromium.runsettings --filter Category=CheckoutTests | To run Checkout Test

Additional Commands
- --settings:Config/<browser>.runsettings | Test accepts 'chromium' and 'firefox' as valid inputs
- --filter Category=<TestCategory> | Tells xunit to only run specific batches of tests

Test Categories
- 'LoginTests'
- 'CheckoutTests'
- 'InventoryTests'
- 'ItemTests'

Runsettings
- Runsettings files are located in Config/<browser>.runsettings
- These files are used when running from commandline

IDE Runsettings
- Runsettings for IDE are located in Config/appsettings.json
- These are used by the IDE Test Explorer when running tests