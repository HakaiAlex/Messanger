using AutoMapper;

namespace Application.Common;

public interface IMapWith<T>
{
    void Mapping(Profile profile);
}
