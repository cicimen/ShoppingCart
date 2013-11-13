using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Concrete;

namespace ShoppingCart.UI.Models
{
    public class SampleData :DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {

            #region Language
            var languages = new List<Language>
            {
                new Language{LanguageCode ="tr",LanguageName ="Türkçe"},
                new Language{LanguageCode ="en",LanguageName ="English"}
            };
            #endregion

            #region Category
            var categories = new List<Category>
            {
                new Category{ DateCreated =DateTime.Now,
                              DateModified = DateTime.Now,
                              CategoryURLText ="cuzdan",
                              CategoryTranslations = new List<CategoryTranslation>
                                  {new CategoryTranslation
                                    {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="Cüzdan",CategoryDescription="Özel Tasarım Cüzdan"},
                                   new CategoryTranslation
                                    {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="Wallet",CategoryDescription="Special Design Wallet"}
                                  }
                            },
                new Category{ DateCreated =DateTime.Now,
                              DateModified = DateTime.Now,
                              CategoryURLText ="saat",
                              CategoryTranslations = new List<CategoryTranslation>
                                  {new CategoryTranslation
                                    {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="Saat",CategoryDescription="Özel Tasarım Saat"},
                                   new CategoryTranslation
                                    {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="Watch",CategoryDescription="Special Design Watch"}
                                  }
                            },
                new Category{ DateCreated =DateTime.Now,
                    DateModified = DateTime.Now,
                    CategoryURLText ="ceket",
                    CategoryTranslations = new List<CategoryTranslation>
                        {new CategoryTranslation
                        {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="Ceket",CategoryDescription="Özel Tasarım Ceket"},
                        new CategoryTranslation
                        {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="Coat",CategoryDescription="Special Design Coat"}
                        }
                },
                new Category{ DateCreated =DateTime.Now,
                    DateModified = DateTime.Now,
                    CategoryURLText ="t-shirt",
                    CategoryTranslations = new List<CategoryTranslation>
                        {new CategoryTranslation
                        {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="T-Shirt",CategoryDescription="Özel Tasarım T-Shirt"},
                        new CategoryTranslation
                        {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="T-Shirt",CategoryDescription="Special Design T-Shirt"}
                        }
                }
            };

            categories.Add(new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CategoryURLText="erkek-saat",
                Parent = categories.Single(x => x.CategoryTranslations.Single(y => y.Language.LanguageCode=="tr").CategoryName== "Saat"),
                Ancestors = new List<CategoryNode>{ new CategoryNode {Ancestor =
                                                    categories.Single(x => x.CategoryTranslations.Single(y => y.Language.LanguageCode=="tr").CategoryName== "Saat") }},
                CategoryTranslations = new List<CategoryTranslation>
                                            {new CategoryTranslation
                                                {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="Erkek Saat",CategoryDescription="Özel Tasarım Erkek Saat"},
                                            new CategoryTranslation
                                                {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="Men Watch",CategoryDescription="Special Design Men Watch"}
                                            }
            });

            categories.Add(new Category{DateCreated = DateTime.Now,
                                        DateModified = DateTime.Now,
                                        CategoryURLText = "kadin-saat",
                                        Parent = categories.Single(x => x.CategoryTranslations.Single(y => y.Language.LanguageCode == "tr").CategoryName == "Saat"),
                                        Ancestors = new List<CategoryNode>{ new CategoryNode {Ancestor =
                                                    categories.Single(x => x.CategoryTranslations.Single(y => y.Language.LanguageCode=="tr").CategoryName== "Saat") }},
                                        CategoryTranslations = new List<CategoryTranslation>
                                            {new CategoryTranslation
                                                {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="Kadın Saat",CategoryDescription="Özel Tasarım Kadın Saat"},
                                            new CategoryTranslation
                                                {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="Women Watch",CategoryDescription="Special Design Women Watch"}
                                            }
                                         });

            categories.Add(new Category
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                CategoryURLText = "kadin-ceket",
                Parent = categories.Single(x => x.CategoryTranslations.Single(y => y.Language.LanguageCode == "tr").CategoryName == "Ceket"),
                Ancestors = new List<CategoryNode>{ new CategoryNode {Ancestor =
                                                    categories.Single(x => x.CategoryTranslations.Single(y => y.Language.LanguageCode=="tr").CategoryName== "Ceket") }},
                CategoryTranslations = new List<CategoryTranslation>
                                            {new CategoryTranslation
                                                {Language = languages.Single(x=>x.LanguageCode =="tr"),CategoryName ="Kadın Ceket",CategoryDescription="Özel Tasarım Kadın Ceket"},
                                            new CategoryTranslation
                                                {Language = languages.Single(x=>x.LanguageCode =="en"),CategoryName ="Women Coat",CategoryDescription="Special Design Women Coat"}
                                            }
            });
            #endregion

            #region Product
            var products = new List<Product>
            {
            #region 1
                new Product
                {
                    Category = categories.Single(x=> x.CategoryTranslations.Single(y=> y.Language.LanguageCode =="tr").CategoryName =="T-Shirt"),
                    DateCreated=DateTime.Now,
                    DateModified = DateTime.Now,
                    DiscountedPrice = 40,
                    Enabled = true,
                    Inventory =5,
                    OriginalPrice = 40,
                    RelatedProducts = new List<Product>{},
                    ProductTranslations = new List<ProductTranslation>
                    {
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="tr"),ProductName ="Good, Bad, Ugly T-Shirt",ProductDescription="Good, Bad, Ugly T-Shirt"},
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="en"),ProductName ="Good, Bad, Ugly T-Shirt",ProductDescription="Good, Bad, Ugly T-Shirt"}
                                            
                    },
                    ProductImages = new List<ProductImage>
                    {
                        new ProductImage
                        {
                            DisplayOrder=1,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/goodbadugly1.jpg"
                        }
                        //,
                        //new ProductImage
                        //{
                        //    DisplayOrder=2,
                        //    ProductImagePath = "path2"
                        //}
                    },
                    ProductAttributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                Enabled=true,
                                ProductAttributeTranslations= new List<ProductAttributeTranslation>
                                                                {
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Renk"
                                                                    },
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Color",
                                                                    }
                                                                },
                                ProductAttributeValues = new List<ProductAttributeValue>
                                                                {
                                                                     new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Siyah"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Black"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Beyaz"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="White"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Kırmızı"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Red"
                                                                                }
                                                                            }
                                                                     }
                                                                }
                            }
                        }
                },
                #endregion

            #region 2
                new Product
                {
                    Category = categories.Single(x=> x.CategoryTranslations.Single(y=> y.Language.LanguageCode =="tr").CategoryName =="Erkek Saat"),
                    DateCreated=DateTime.Now,
                    DateModified = DateTime.Now,
                    DiscountedPrice = 40,
                    Enabled = true,
                    Inventory =5,
                    OriginalPrice = 40,
                    RelatedProducts = new List<Product>{},
                    ProductTranslations = new List<ProductTranslation>
                    {
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="tr"),ProductName ="Deri Erkek Saat",ProductDescription="Özel Tasarım Erkek Saat Deri"},
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="en"),ProductName ="Leather Men Watch",ProductDescription="Special Design Men Watch Leather "}
                                            
                    },
                    ProductImages = new List<ProductImage>
                    {
                        new ProductImage
                        {
                            DisplayOrder=1,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/derierkeksaat1.jpg"
                        },
                        new ProductImage
                        {
                            DisplayOrder=2,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/derierkeksaat2.jpg"
                        }
                    },
                    ProductAttributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                Enabled=true,
                                ProductAttributeTranslations= new List<ProductAttributeTranslation>
                                                                {
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Renk"
                                                                    },
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Color",
                                                                    }
                                                                },
                                ProductAttributeValues = new List<ProductAttributeValue>
                                                                {
                                                                     new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Siyah"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Black"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Beyaz"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="White"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Kırmızı"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Red"
                                                                                }
                                                                            }
                                                                     }
                                                                }
                            }
                        }
                },
                #endregion 

            #region 3
                new Product
                {
                    Category = categories.Single(x=> x.CategoryTranslations.Single(y=> y.Language.LanguageCode =="tr").CategoryName =="Kadın Saat"),
                    DateCreated=DateTime.Now,
                    DateModified = DateTime.Now,
                    DiscountedPrice = 60,
                    Enabled = true,
                    Inventory =15,
                    OriginalPrice = 60,
                    RelatedProducts = new List<Product>{},
                    ProductTranslations = new List<ProductTranslation>
                    {
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="tr"),ProductName ="Deri Kadın Saat",ProductDescription="Özel Tasarım Erkek Saat Deri"},
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="en"),ProductName ="Leather Women Watch",ProductDescription="Special Design Women Watch Leather "}
                                            
                    },
                    ProductImages = new List<ProductImage>
                    {
                        new ProductImage
                        {
                            DisplayOrder=1,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/derikadinsaat1.jpg"
                        }
                        //,
                        //new ProductImage
                        //{
                        //    DisplayOrder=2,
                        //    ProductImagePath = "path2"
                        //}
                    },
                    ProductAttributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                Enabled=true,
                                ProductAttributeTranslations= new List<ProductAttributeTranslation>
                                                                {
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Renk"
                                                                    },
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Color",
                                                                    }
                                                                },
                                ProductAttributeValues = new List<ProductAttributeValue>
                                                                {
                                                                     new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Siyah"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Black"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Beyaz"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="White"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Kırmızı"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Red"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Mavi"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Blue"
                                                                                }
                                                                            }
                                                                     }
                                                                }
                            }
                        }
                },
                #endregion

            #region 4
                new Product
                {
                    Category = categories.Single(x=> x.CategoryTranslations.Single(y=> y.Language.LanguageCode =="tr").CategoryName =="Cüzdan"),
                    DateCreated=DateTime.Now,
                    DateModified = DateTime.Now,
                    DiscountedPrice = 40,
                    Enabled = true,
                    Inventory =5,
                    OriginalPrice = 40,
                    RelatedProducts = new List<Product>{},
                    ProductTranslations = new List<ProductTranslation>
                    {
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="tr"),ProductName ="Marilyn Monroe Deri Cüzdan",ProductDescription="Marilyn Monroe Deri Cüzdan"},
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="en"),ProductName ="Marilyn Monroe Leather Wallet",ProductDescription="Marilyn Monroe Leather Wallet"}
                                            
                    },
                    ProductImages = new List<ProductImage>
                    {
                        new ProductImage
                        {
                            DisplayOrder=1,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/marilynmonroedericuzdan1.jpg"
                        },
                        new ProductImage
                        {
                            DisplayOrder=2,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/marilynmonroedericuzdan2.jpg"
                        },
                        new ProductImage
                        {
                            DisplayOrder=2,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/marilynmonroedericuzdan3.jpg"
                        }
                    },
                    ProductAttributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                Enabled=true,
                                ProductAttributeTranslations= new List<ProductAttributeTranslation>
                                                                {
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Renk"
                                                                    },
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Color",
                                                                    }
                                                                },
                                ProductAttributeValues = new List<ProductAttributeValue>
                                                                {
                                                                     new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Siyah"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Black"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Beyaz"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="White"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Kırmızı"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Red"
                                                                                }
                                                                            }
                                                                     }
                                                                }
                            }
                        }
                }

                #endregion

            #region 5
                ,
                new Product
                {
                    Category = categories.Single(x=> x.CategoryTranslations.Single(y=> y.Language.LanguageCode =="tr").CategoryName =="Kadın Ceket"),
                    DateCreated=DateTime.Now,
                    DateModified = DateTime.Now,
                    DiscountedPrice = 40,
                    Enabled = true,
                    Inventory =5,
                    OriginalPrice = 40,
                    RelatedProducts = new List<Product>{},
                    ProductTranslations = new List<ProductTranslation>
                    {
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="tr"),ProductName ="Heidi Kaban",ProductDescription="Heidi Kaban"},
                        new ProductTranslation
                            {Language = languages.Single(x=>x.LanguageCode =="en"),ProductName ="Heidi Coat",ProductDescription="Heidi Coat"}
                                            
                    },
                    ProductImages = new List<ProductImage>
                    {
                        new ProductImage
                        {
                            DisplayOrder=1,
                            ProductImageMimeType ="image/jpeg",
                            ProductImagePath = "/Content/ProductImages/hedicoat1.jpg"
                        }
                    },
                    ProductAttributes = new List<ProductAttribute>
                        {
                            new ProductAttribute
                            {
                                Enabled=true,
                                ProductAttributeTranslations= new List<ProductAttributeTranslation>
                                                                {
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Renk"
                                                                    },
                                                                    new ProductAttributeTranslation
                                                                    {
                                                                        Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                        ProductAttributeDescription ="",
                                                                        ProductAttributeName ="Color",
                                                                    }
                                                                },
                                ProductAttributeValues = new List<ProductAttributeValue>
                                                                {
                                                                     new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Siyah"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Black"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Beyaz"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="White"
                                                                                }
                                                                            }
                                                                     },
                                                                      new ProductAttributeValue
                                                                     {
                                                                        Enabled = true,
                                                                        ProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>
                                                                            {
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="tr"),
                                                                                    ProductAttributeValueName ="Kırmızı"
                                                                                },
                                                                                new ProductAttributeValueTranslation
                                                                                {
                                                                                    Language =languages.Single(x=> x.LanguageCode =="en"),
                                                                                    ProductAttributeValueName ="Red"
                                                                                }
                                                                            }
                                                                     }
                                                                }
                            }
                        }
                }
            #endregion


            };
            #endregion

            var product1 = products.Single(x => x.ProductTranslations.Single(y => y.Language.LanguageCode == "tr").ProductName == "Deri Erkek Saat");
            var product2 = products.Single(x => x.ProductTranslations.Single(y => y.Language.LanguageCode == "tr").ProductName == "Deri Kadın Saat");
            var product3 = products.Single(x => x.ProductTranslations.Single(y => y.Language.LanguageCode == "tr").ProductName == "Marilyn Monroe Deri Cüzdan");
            product1.RelatedProducts.Add(product2);
            product2.RelatedProducts.Add(product1);
            product2.RelatedProducts.Add(product3);
            product3.RelatedProducts.Add(product1);


            foreach (var item in products)
            {
                context.Products.Add(item);
            }
        
        }
    }
}