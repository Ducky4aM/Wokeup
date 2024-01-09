using Infrastructure.DTO;

namespace Infrastructure.Interface
{
    public interface IGenreRepository
    {
        IReadOnlyList<GenreDTO> GetAllGenre();

        IReadOnlyList<ArtistDTO> GetAllArtistBaseOnGenre(GenreDTO genreDto);
    }
}