using AutoMapper;
using ServerlessToDoList.Web.ApiModels.ToDoList;
using ServerlessToDoList.Web.ApiModels.ToDoListItem;
using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ToDoListItem, ToDoListItemResponse>();

        CreateMap<ToDoList, ToDoListResponse>();
    }
}