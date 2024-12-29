using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {

        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.SeoAuthor).IsRequired();
            builder.Property(x => x.SeoAuthor).HasMaxLength(0);
            builder.Property(x => x.SeoDescription).HasMaxLength(150);
            builder.Property(x => x.SeoDescription).IsRequired();
            builder.Property(x => x.SeoTags).IsRequired();
            builder.Property(x => x.SeoTags).HasMaxLength(70);
            builder.Property(x => x.ViewCount).IsRequired();
            builder.Property(x => x.CommentCount).IsRequired();
            builder.Property(X => X.Thumbnail).IsRequired();
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.HasOne<Category>(x => x.Category).WithMany(c => c.Articles).HasForeignKey(x => x.CategoryId);
            builder.HasOne<User>(x => x.User).WithMany(C => C.Articles).HasForeignKey(a => a.UserId);
            builder.ToTable("Articles");


            builder.HasData(

                new Article
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "C# 9.0 ve.NET 5Yenilikleri",
                    Content = "Lorem Ipsum, basitçe baskı ve dizgi endüstrisinin sahte metnidir. Lorem Ipsum, bilinmeyen bir yazıcının bir yazı galerisini alıp karıştırarak bir yazı örneği kitabı yaptığı 1500'lerden beri endüstrinin standart sahte metni olmuştur. Sadece beş yüzyılı değil, aynı zamanda elektronik dizgiye geçişi de atlatmış ve temelde değişmeden kalmıştır. 1960'larda Lorem Ipsum pasajlarını içeren Letraset sayfalarının piyasaya sürülmesiyle ve daha yakın zamanda Aldus PageMaker gibi masaüstü yayıncılık yazılımlarının Lorem Ipsum sürümlerini içermesiyle popüler hale gelmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C# 9.0 ve.NET 5 Yenilikleri",
                    SeoTags = "C# ,C# 9 ,.NET5, ,Framework,.NET Core",
                    SeoAuthor = "Alper Tunga",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# 9.0 ve.NET 5 Yenilikleri",
                    UserId = 1,
                    ViewCount =100,
                    CommentCount = 1
                    


                },
                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "C++ 11 ve 19 Yenilikleri",
                    Content = "Bir okuyucunun bir sayfanın okunabilir içeriğine bakarken, onun düzenine dikkati dağılacağı uzun zamandır bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, 'Burada içerik, burada içerik' kullanmak yerine, harflerin az çok normal bir dağılımına sahip olması ve okunabilir İngilizce gibi görünmesini sağlamasıdır. Birçok masaüstü yayıncılık paketi ve web sayfası düzenleyicisi artık varsayılan model metinleri olarak Lorem Ipsum'u kullanıyor ve 'lorem ipsum' için yapılan bir arama, hala emekleme aşamasında olan birçok web sitesini ortaya çıkaracaktır. Yıllar içinde, bazen kazara, bazen de bilerek (eklenen mizah vb.) çeşitli sürümler geliştirilmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C# 9.0 ve.NET 5 Yenilikleri",
                    SeoTags = "C++ 11 ve 19 Yenilikleri",
                    SeoAuthor = "Alper Tunga",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ 11 ve 19 Yenilikleri",
                    UserId = 1,
                    ViewCount = 295,
                    CommentCount = 1

                },
                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "JavaScript ES2019 VE-e ES2020 Yenilikleri",
                    Content = "Yaygın inancın aksine, Lorem Ipsum sadece rastgele bir metin değildir. Kökleri MÖ 45'ten kalma klasik Latin edebiyatına dayanır ve bu da onu 2000 yıldan daha eski yapar. Virginia'daki Hampden-Sydney College'da Latince profesörü olan Richard McClintock, daha az bilinen Latince kelimelerden biri olan consectetur'u bir Lorem Ipsum pasajından araştırdı ve kelimenin klasik edebiyattaki alıntılarını inceleyerek şüphesiz kaynağı keşfetti. Lorem Ipsum, MÖ 45'te yazılan Cicero'nun \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uçları) adlı eserinin 1.10.32 ve 1.10.33 bölümlerinden gelir. Bu kitap, Rönesans döneminde çok popüler olan etik teorisi üzerine bir incelemedir. Lorem Ipsum'un ilk satırı, \"Lorem ipsum dolor sit amet..\", 1.10.32 bölümündeki bir satırdan gelir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "JavaScript ES2019 VE-e ES2020 Yenilikleri",
                    SeoTags = "JavaScript ES2019 VE-e ES2020 Yenilikleri",
                    SeoAuthor = "Alper Tunga",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript ES2019 VE-e ES2020 Yenilikleri",
                    UserId = 1,
                    ViewCount = 12,
                    CommentCount = 1

                });






        }

    }
}
