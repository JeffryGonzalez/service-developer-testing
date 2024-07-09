

using Alba;
using Catalog.Api.Catalog;


namespace Catalog.Tests.Catalog;
public class AddingToTheCatalog : IClassFixture<CatalogFixture>
{

    private IAlbaHost _host;
    public AddingToTheCatalog(CatalogFixture fixture)
    {
        _host = fixture.Host;
    }


    [Fact]
    public async Task DoIt()
    {

        var newCatalogItem = new CreateCatalogItemRequest
        {
            Version = "1.91",
            IsCommercial = true,
            AnnualCostPerSeat = 2.99M
        };

        var expectedResponse = new CatalogItemResponse
        {
            Vendor = "microsoft",
            Application = "visualstudio",
            AnnualCostPerSeat = 2.99M,
            Version = "1.91"
        };
        var postResponse = await _host.Scenario(api =>
         {
             api.Post.Json(newCatalogItem).ToUrl("/catalog/microsoft/visualstudio");
             api.StatusCodeShouldBe(201);
         });

        var postBody = await postResponse.ReadAsJsonAsync<CatalogItemResponse>();
        Assert.NotNull(postBody);

        Assert.Equal(expectedResponse, postBody);

        var getResponse = await _host.Scenario(api =>
        {
            api.Get.Url("/catalog/microsoft/visualstudio/1.91");
            api.StatusCodeShouldBeOk();
        });

        var getBody = await getResponse.ReadAsJsonAsync<CatalogItemResponse>();

        Assert.Equal(postBody, getBody);

    }
}
