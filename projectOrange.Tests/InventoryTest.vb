Imports System.Collections.Generic

Imports projectOrange.Models.Inventory.DTOs

Imports Microsoft.VisualStudio.TestTools.UnitTesting.Web

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports projectOrange.Services.Read



'''<summary>
'''This is a test class for InventoryTest and is intended
'''to contain all InventoryTest Unit Tests
'''</summary>
<TestClass()> _
Public Class InventoryTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for GetAllItems
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("C:\Users\nbarger.ARTHREX\Dropbox\Development\ProjectOrange\projectOrange\projectOrange.Services", "/"), _
     UrlToTest("http://localhost:25187/")> _
    Public Sub GetAllItemsTest()
        Dim target As Inventory = New Inventory()
        Dim languageId As Integer = 1
        Dim currencyId As Integer = 1
        Dim expected As IEnumerable(Of BasicItem) = Nothing
        Dim actual As IEnumerable(Of BasicItem)
        actual = target.GetAllItems(languageId, currencyId)

        Assert.IsTrue(actual.Count > 0)
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for GetItem
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("C:\Users\nbarger.ARTHREX\Dropbox\Development\ProjectOrange\projectOrange\projectOrange.Services", "/"), _
     UrlToTest("http://localhost:25187/")> _
    Public Sub GetItemTest()
        Dim target As Inventory = New Inventory()
        Dim id As Integer = 1
        Dim languageId As Integer = 1
        Dim currencyId As Integer = 1
        Dim expected As FullItem = Nothing
        Dim actual As FullItem
        actual = target.GetItem(id, languageId, currencyId)

        Dim code As String = "O-1000"
        Dim price As Decimal = 10

        Assert.AreEqual(actual.Code, code)
        Assert.AreEqual(actual.ContentInActiveLanguageName, "Torso-Friendly Hadron Collider")
        Assert.AreEqual(actual.BaseInActiveCurrencyAmountPerUnitValue, price)
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for SearchItems
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("C:\Users\nbarger.ARTHREX\Dropbox\Development\ProjectOrange\projectOrange\projectOrange.Services", "/"), _
     UrlToTest("http://localhost:25187/")> _
    Public Sub SearchItemsTest()
        Dim target As Inventory = New Inventory()
        Dim languageId As Integer = 1
        Dim currencyId As Integer = 1
        Dim text As String = "had"
        Dim expected As IEnumerable(Of BasicItem) = Nothing
        Dim actual As IEnumerable(Of BasicItem)
        actual = target.SearchItems(languageId, currencyId, text)

        Assert.AreEqual(expected, actual)
    End Sub

    'TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
    ' http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
    ' whether you are testing a page, web service, or a WCF service.
    '''<summary>
    '''A test for SearchItemsComplex
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("C:\Users\nbarger.ARTHREX\Dropbox\Development\ProjectOrange\projectOrange\projectOrange.Services", "/"), _
     UrlToTest("http://localhost:25187/")> _
    Public Sub SearchItemsComplexTest()
        Dim target As Inventory = New Inventory()
        Dim languageId As Integer = 1
        Dim currencyId As Integer = 1
        Dim code As String = String.Empty
        Dim text As String = "had"
        Dim categoryId As Integer = 0
        Dim catalogId As Integer = 0
        Dim expected As IEnumerable(Of BasicItem) = Nothing
        Dim actual As IEnumerable(Of BasicItem)
        actual = target.SearchItemsComplex(languageId, currencyId, code, text, categoryId, catalogId)

        Assert.AreEqual(expected, actual)
    End Sub
End Class
