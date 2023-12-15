using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			// About
			CreateMap<About, CreateAboutDto>().ReverseMap();
			CreateMap<About, ResultAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();

			// Booking
			CreateMap<Booking, CreateBookingDto>().ReverseMap();
			CreateMap<Booking, ResultBookingDto>().ReverseMap();
			CreateMap<Booking, UpdateBookingDto>().ReverseMap();

			// Category
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			// Contact
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();

			// Discount
			CreateMap<Discount, CreateDiscountDto>().ReverseMap();
			CreateMap<Discount, ResultDiscountDto>().ReverseMap();
			CreateMap<Discount, UpdateDiscountDto>().ReverseMap();

			// Product
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

			// Social Media
			CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

			// Testimonial
			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

			// Slider
			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();

		}
	}
}
