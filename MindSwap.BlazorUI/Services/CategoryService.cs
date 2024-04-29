using AutoMapper;
using MindSwap.BlazorUI.Contracts;
using MindSwap.BlazorUI.Moduls.Categories;
using MindSwap.BlazorUI.Services.Base;

namespace MindSwap.BlazorUI.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IMapper _mapper;

        public CategoryService(IClient client, IMapper mapper) : base(client)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreateCategory(CategoryVM category)
        {
            try
            {
                var createCategoryCommand = _mapper.Map<CreateCategoryCommand>(category);
                await _client.CategoriesPOSTAsync(createCategoryCommand);
                return new Response<Guid>
                {
                    Success = true
                };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }

        }

        public async Task<Response<Guid>> DeleteCategory(int id)
        {
            try
            {
                await _client.CategoriesDELETEAsync(id);
                return new Response<Guid>
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<CategoryVM>> GetCategories()
        {
            var categories = await _client.CategoriesAllAsync();
            return _mapper.Map<List<CategoryVM>>(categories);

        }

        public async Task<CategoryVM> GetCategoryDetails(int id)
        {
            var category = await _client.CategoriesGETAsync(id);
            return _mapper.Map<CategoryVM>(category);
        }

        public async Task<Response<Guid>> UpdateCategory(int id, CategoryVM category)
        {
            try
            {
                var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
                await _client.CategoriesPUTAsync(id.ToString(),updateCategoryCommand);
                return new Response<Guid>
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }

        }
    }
}
