using Demo_WebAPI.BLL.Models;

namespace Demo_WebAPI.DTO.Mappers
{
    public static class BeerMapper
    {
        public static BeerDTO ToDTO(this Beer model)
        {
            return new BeerDTO
            {
                Id = model.Id,
                Name = model.Name,
                CreateDate = model.CreateDate,
                Variety = model.Variety,
                Degree = model.Degree,
                Brewery = model.Brewery
            };
        }

        public static Beer ToModel(this BeerDataDTO data)
        {
            return new Beer(
                -1,
                data.Name,
                data.Variety, 
                data.CreateDate,
                data.Degree,
                data.Brewery
            ); 
        }
    }
}
