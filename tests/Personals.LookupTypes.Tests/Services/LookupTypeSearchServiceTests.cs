using Personals.Common.Contracts.LookupTypes;
using Personals.Common.Enums;
using Personals.Infrastructure.Abstractions.Repositories;
using Personals.LookupTypes.Abstractions.Repositories;
using Personals.LookupTypes.Entities;
using Personals.LookupTypes.Repositories;
using Personals.LookupTypes.Services;
using Personals.Tests.Base.Factories;

namespace Personals.LookupTypes.Tests.Services;

public class LookupTypeSearchServiceTests
{
    private readonly IUnitOfWork _unitOfWorkStub = Substitute.For<IUnitOfWork>();
    private readonly ILookupTypeRepository _lookupTypeRepositoryStub = Substitute.For<ILookupTypeRepository>();

    private LookupTypeSearchService LookupTypeService
    {
        get
        {
            _unitOfWorkStub.Repository<LookupType, ILookupTypeRepository, LookupTypeRepository>()
                .Returns(_lookupTypeRepositoryStub);
            return new LookupTypeSearchService(_unitOfWorkStub);
        }
    }

    [Fact]
    public async Task SearchExpenseTypesAsync_ShouldReturnExpenseTypes_WhenExpenseTypesFound()
    {
        // Arrange
        const string searchString = "search";
        var lookupTypes = new List<LookupType>
        {
            LookupTypeFactory.Create(Guid.NewGuid(), LookupTypeCategory.ExpenseType, Guid.NewGuid(), "CODE_1", "Expense Type 1"),
            LookupTypeFactory.Create(Guid.NewGuid(), LookupTypeCategory.ExpenseType, Guid.NewGuid(), "CODE_2", "Expense Type 2")
        };

        _lookupTypeRepositoryStub.GetAllLookupTypesAsync(LookupTypeCategory.ExpenseType, 1, 5, searchString)
            .Returns(lookupTypes);

        var expectedLookupTypes = lookupTypes.Select(x => new LookupTypeSearchResponse(x.Id, x.Code, x.Name)).ToList();

        // Act
        var result = await LookupTypeService.SearchExpenseTypesAsync(searchString);

        // Assert
        result.Should().BeEquivalentTo(expectedLookupTypes);
    }

    [Fact]
    public async Task SearchExpenseTypesAsync_ShouldReturnEmptyList_WhenNoExpenseTypesFound()
    {
        // Arrange
        const string searchString = "search";

        _lookupTypeRepositoryStub.GetAllLookupTypesAsync(LookupTypeCategory.ExpenseType, 1, 5, searchString)
            .Returns([]);

        // Act
        var result = await LookupTypeService.SearchExpenseTypesAsync(searchString);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task SearchPaymentMethodsAsync_ShouldReturnPaymentMethods_WhenPaymentMethodsFound()
    {
        // Arrange
        const string searchString = "search";
        var lookupTypes = new List<LookupType>
        {
            LookupTypeFactory.Create(Guid.NewGuid(), LookupTypeCategory.PaymentMethod, Guid.NewGuid(), "CODE_1",
                "Payment Method 1"),
            LookupTypeFactory.Create(Guid.NewGuid(), LookupTypeCategory.PaymentMethod, Guid.NewGuid(), "CODE_2", "Payment Method 2")
        };

        _lookupTypeRepositoryStub.GetAllLookupTypesAsync(LookupTypeCategory.PaymentMethod, 1, 5, searchString)
            .Returns(lookupTypes);

        var expectedLookupTypes = lookupTypes.Select(x => new LookupTypeSearchResponse(x.Id, x.Code, x.Name)).ToList();

        // Act
        var result = await LookupTypeService.SearchPaymentMethodsAsync(searchString);

        // Assert
        result.Should().BeEquivalentTo(expectedLookupTypes);
    }


    [Fact]
    public async Task SearchPaymentMethodsAsync_ShouldReturnEmptyList_WhenNoPaymentMethodsFound()
    {
        // Arrange
        const string searchString = "search";

        _lookupTypeRepositoryStub.GetAllLookupTypesAsync(LookupTypeCategory.PaymentMethod, 1, 5, searchString)
            .Returns([]);

        // Act
        var result = await LookupTypeService.SearchPaymentMethodsAsync(searchString);

        // Assert
        result.Should().BeEmpty();
    }
}