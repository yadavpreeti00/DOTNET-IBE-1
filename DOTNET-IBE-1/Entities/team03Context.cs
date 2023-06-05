using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DOTNET_IBE_1.Entities
{
    public partial class team03Context : DbContext
    {
        public team03Context()
        {
        }

        public team03Context(DbContextOptions<team03Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; } = null!;
        public virtual DbSet<CustomPromotion> CustomPromotions { get; set; } = null!;
        public virtual DbSet<RoomRating> RoomRatings { get; set; } = null!;
        public virtual DbSet<RoomTypeRoomId> RoomTypeRoomIds { get; set; } = null!;
        public virtual DbSet<SpecialOffersEmail> SpecialOffersEmails { get; set; } = null!;
        public virtual DbSet<UserSearchRequest> UserSearchRequests { get; set; } = null!;

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("booking_details_pkey");

                entity.ToTable("booking_details", "ibe_schema");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .HasColumnName("booking_id");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(255)
                    .HasColumnName("card_number");

                entity.Property(e => e.CheckInDate)
                    .HasMaxLength(255)
                    .HasColumnName("check_in_date");

                entity.Property(e => e.CheckOutDate)
                    .HasMaxLength(255)
                    .HasColumnName("check_out_date");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomPromotionPromoCode)
                    .HasMaxLength(255)
                    .HasColumnName("custom_promotion_promo_code");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.Guests)
                    .HasMaxLength(255)
                    .HasColumnName("guests");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(255)
                    .HasColumnName("mailing_address1");

                entity.Property(e => e.NightlyRate)
                    .HasMaxLength(255)
                    .HasColumnName("nightly_rate");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.PromoTitle)
                    .HasMaxLength(255)
                    .HasColumnName("promo_title");

                entity.Property(e => e.PromotionDescription)
                    .HasMaxLength(255)
                    .HasColumnName("promotion_description");

                entity.Property(e => e.PropertyId)
                    .HasMaxLength(255)
                    .HasColumnName("property_id");

                entity.Property(e => e.RoomCount)
                    .HasMaxLength(255)
                    .HasColumnName("room_count");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(255)
                    .HasColumnName("room_type");

                entity.Property(e => e.RoomsList)
                    .HasMaxLength(255)
                    .HasColumnName("rooms_list");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.Subtotal)
                    .HasMaxLength(255)
                    .HasColumnName("subtotal");

                entity.Property(e => e.Taxes)
                    .HasMaxLength(255)
                    .HasColumnName("taxes");

                entity.Property(e => e.TotalForStay)
                    .HasMaxLength(255)
                    .HasColumnName("total_for_stay");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");

                entity.Property(e => e.Vat)
                    .HasMaxLength(255)
                    .HasColumnName("vat");

                entity.Property(e => e.Zip)
                    .HasMaxLength(255)
                    .HasColumnName("zip");

                entity.HasOne(d => d.CustomPromotionPromoCodeNavigation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.CustomPromotionPromoCode)
                    .HasConstraintName("fkr1hysw43qey392p4ei29kqg83");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("booking_status_pkey");

                entity.ToTable("booking_status", "ibe_schema");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .HasColumnName("booking_id");

                entity.Property(e => e.BookingStatus1).HasColumnName("booking_status");
            });

            modelBuilder.Entity<CustomPromotion>(entity =>
            {
                entity.HasKey(e => e.PromoCode)
                    .HasName("custom_promotion_pkey");

                entity.ToTable("custom_promotion", "ibe_schema");

                entity.Property(e => e.PromoCode)
                    .HasMaxLength(255)
                    .HasColumnName("promo_code");

                entity.Property(e => e.ApplicableRoomType)
                    .HasMaxLength(255)
                    .HasColumnName("applicable_room_type");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(255)
                    .HasColumnName("error_message");

                entity.Property(e => e.IsDeactivated).HasColumnName("is_deactivated");

                entity.Property(e => e.MinimumDaysOfStay).HasColumnName("minimum_days_of_stay");

                entity.Property(e => e.PriceFactor).HasColumnName("price_factor");

                entity.Property(e => e.PromotionDescription)
                    .HasMaxLength(255)
                    .HasColumnName("promotion_description");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.PromotionTitle)
                    .HasMaxLength(255)
                    .HasColumnName("promotion_title");
            });

            modelBuilder.Entity<RoomRating>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("room_ratings_pkey");

                entity.ToTable("room_ratings", "ibe_schema");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .HasColumnName("booking_id");

                entity.Property(e => e.CheckInDate).HasColumnName("check_in_date");

                entity.Property(e => e.CheckOutDate).HasColumnName("check_out_date");

                entity.Property(e => e.IsRated).HasColumnName("is_rated");

                entity.Property(e => e.MailSent).HasColumnName("mail_sent");

                entity.Property(e => e.Review)
                    .HasMaxLength(255)
                    .HasColumnName("review");

                entity.Property(e => e.RoomRating1).HasColumnName("room_rating");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(255)
                    .HasColumnName("room_type");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .HasColumnName("user_email");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<RoomTypeRoomId>(entity =>
            {
                entity.ToTable("room_type_room_id", "ibe_schema");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .HasColumnName("booking_id");

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .HasColumnName("date");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(255)
                    .HasColumnName("room_type");
            });

            modelBuilder.Entity<SpecialOffersEmail>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("special_offers_email_pkey");

                entity.ToTable("special_offers_email", "ibe_schema");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
            });

            modelBuilder.Entity<UserSearchRequest>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_search_request_pkey");

                entity.ToTable("user_search_request", "ibe_schema");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");

                entity.Property(e => e.SearchRequest)
                    .HasMaxLength(255)
                    .HasColumnName("search_request");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
