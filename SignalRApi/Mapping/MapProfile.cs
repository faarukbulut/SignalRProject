using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
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
			CreateMap<About, GetAboutDto>().ReverseMap();
			CreateMap<About, ResultAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();

			// Booking
			CreateMap<Booking, CreateBookingDto>().ReverseMap();
			CreateMap<Booking, GetBookingDto>().ReverseMap();
			CreateMap<Booking, ResultBookingDto>().ReverseMap();
			CreateMap<Booking, UpdateBookingDto>().ReverseMap();

			// Category
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, GetCategoryDto>().ReverseMap();
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			// Contact
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, GetContactDto>().ReverseMap();
			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();

			// Discount
			CreateMap<Discount, CreateDiscountDto>().ReverseMap();
			CreateMap<Discount, GetDiscountDto>().ReverseMap();
			CreateMap<Discount, ResultDiscountDto>().ReverseMap();
			CreateMap<Discount, UpdateDiscountDto>().ReverseMap();

			// Feature
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, GetFeatureDto>().ReverseMap();
			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

			// Product
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, GetProductDto>().ReverseMap();
			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

			// Social Media
			CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

			// Testimonial
			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
		}
	}
}
