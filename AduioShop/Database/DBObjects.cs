﻿using AudioShop.Data.Models;

namespace AudioShop.Database
{
    public class DBObjects
    {
        public static void Initial(AudioShopDBContext context)
        {


            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Product.Any())
            {
                context.AddRange(
                    new Product(
                        productType: "Headphones",
                        brand: "Apple",
                        name: "Powerbeats Pro",
                        description: "Powerbeats Pro оснащені чипом Apple H1, що дозволяє користуватися голосовим помічником Siri, а також швидко з'єднуватися з пристроями Apple. Кнопки регулювання гучності і управління дзвінками на навушнику.\r\nСенсор положення включає музику тільки коли ви використовуєте навушники. Перероблений акумулятор дозволяє слухати музику до 9 годин. 5 хвилин зарядки вистачає на 1.5 години роботи.\r\nВисокоякісні бездротові внутрішньоканальні навушники класу True Wireless для активних занять спортом. Обладнані надійною системою кріплення у вушній раковині з настроюваної завушної дужкою, яка гарантує утримання навушників при інтенсивному бігу, стрибках та інших різких амплітудних рухах. Повністю захищені від попадання атмосферних опадів і обладнані вбудованими всеспрямованими мікрофонами для роботи в режимі гарнітури Hands Free.\r\n\r\nПозиціонуються виробником як продукт верхньої цінової категорії 2019 року, призначений для користувачів гаджетів компанії Apple. Апаратною основою бездротових навушників Beats Powerbeats Pro став топовий чипсет Apple H1 (той самий, що і в AirPods 2). Він забезпечує з'єднання з джерелом звуку (смартфоном, планшетом, ноутбуком) по інтерфейсу Bluetooth 5.0 Class 1. Передбачено механічне кнопкове управління, що дозволяє легко регулювати гучність і черговість відтворення треків.\r\n\r\nКожен слуховий апарат оснащений Li-Ion акумулятором на 9 годин безперервної роботи, а з використанням комплектного футляра для підзарядки час прослуховування може досягати 24 год. Підтримується технологія швидкої зарядки Fast Fuel (п'ятихвилинного перебування на зарядці достатньо для півторагодинного прослуховування музики). Є вбудовані оптичні датчики, які автоматично починають/призупиняють відтворення музики, коли навушники вставляються/видаляються з вух.",
                        shortDesc: "Powerbeats Pro оснащені чипом Apple H1, що дозволяє користуватися голосовим помічником Siri, а також швидко з'єднуватися з пристроями Apple. Кнопки регулювання гучності і управління дзвінками на навушнику.",
                        img: "/img/Headphones/Powerbeats Pro/Powerbeats Pro-1.jpg",
                        price: 6400,
                        isFavorite: true,
                        isAvailible: true,
                        imageUrls: new List<ProductImages>
                        {
                            new ProductImages {Name = "Powerbeats Pro-1.jpg", ImageUrls = "/img/Headphones/Powerbeats Pro/Powerbeats Pro-1.jpg" },
                            new ProductImages {Name = "Powerbeats Pro-2.jpg", ImageUrls = "/img/Headphones/Powerbeats Pro/Powerbeats Pro-2.jpg" },
                            new ProductImages {Name = "Powerbeats Pro-3.jpg", ImageUrls = "/img/Headphones/Powerbeats Pro/Powerbeats Pro-3.jpg" },
                            new ProductImages {Name = "Powerbeats Pro-4.jpg", ImageUrls = "/img/Headphones/Powerbeats Pro/Powerbeats Pro-4.jpg" },
                            new ProductImages {Name = "Powerbeats Pro-5.jpg", ImageUrls = "/img/Headphones/Powerbeats Pro/Powerbeats Pro-5.jpg" }
                        },
                        categoryId: 1,
                        category: Categories["Headphones"]
                        ),
                    new Product(
                        productType: "Headphones",
                        brand: "Apple",
                        name: "AirPods Max Silver",
                        description: "Чіп Apple H1. Вісім мікрофонів у системі активного шумозаглушення. В кишені Smart Case практично не витрачається енергія. 5 хвилин зарядки дають 1.5 години роботи. Функція відстеження рухів голови. Технологія просторового аудіо. Адаптивний еквалайзер.\r\nВисокотехнологічні іміджеві накладні bluetooth-навушники закритого типу з поворотними чашами і системою активного шумозаглушення. Позиціонуються як продукт преміумкласу, орієнтований на забезпечених користувачів, що бажають придбати повнорозмірні накладні навушники для використання в екосистемі Apple. Всі елементи конструкції, від амбушюрів до оголів'я, спроєктовані таким чином, щоб забезпечити комфортну посадку на голові будь-якого розміру і форми.\r\n\r\nВерхня частина наголів'я виконана з дихаючої тканини, рівномірно розподіляє вагу навушників і зменшує ефект дискомфортного тиску на голову. Телескопічні дужки з нержавіючої сталі плавно висуваються і надійно фіксуються в обраній позиції, забезпечуючи комфортне положення і ідеальне прилягання амбушюрів. Амбушюри навушників Apple AirPods Max із спеціально підібраного пінополімерного матеріалу з ефектом пам'яті м'яко закривають вушну раковину, забезпечують повноцінну звукоізоляцію і створюють оптимальні умови для приголомшливо якісного звучання драйверів з двома кільцевими неодимовими магнітами. Така конструкція гарантує мінімум гармонійних спотворень у всьому частотному діапазоні і навушники зберігають чистоту звучання навіть на самій високій гучності. Два звукових процесора Apple H1 (по одному в кожному навушнику), вбудовані гіроскопи і передове ПЗ виконують цифрову обробку звуку з урахуванням положення голови і прилягання навушників.",
                        shortDesc: "Чіп Apple H1. Вісім мікрофонів у системі активного шумозаглушення. В кишені Smart Case практично не витрачається енергія. 5 хвилин зарядки дають 1.5 години роботи. Функція відстеження рухів голови. Технологія просторового аудіо. Адаптивний еквалайзер.",
                        img: "/img/Headphones/AirPods Max Silver/AirPods Max Silver-1.jpg",
                        price: 21650,
                        isFavorite: false,
                        isAvailible: true,
                        imageUrls: new List<ProductImages>
                        {
                            new ProductImages {Name = "AirPods Max Silver-1.jpg", ImageUrls = "/img/Headphones/AirPods Max Silver/AirPods Max Silver-1.jpg" },
                            new ProductImages {Name = "AirPods Max Silver-2.jpg", ImageUrls = "/img/Headphones/AirPods Max Silver/AirPods Max Silver-2.jpg" },
                            new ProductImages {Name = "AirPods Max Silver-3.jpg", ImageUrls = "/img/Headphones/AirPods Max Silver/AirPods Max Silver-3.jpg" },
                            new ProductImages {Name = "AirPods Max Silver-4.jpg", ImageUrls = "/img/Headphones/AirPods Max Silver/AirPods Max Silver-4.jpg" },
                            new ProductImages {Name = "AirPods Max Silver-5.jpg", ImageUrls = "/img/Headphones/AirPods Max Silver/AirPods Max Silver-5.jpg" }
                        },
                        categoryId: 1,
                        category: Categories["Headphones"]
                        ),
                    new Product(
                        productType: "Headphones",
                        brand: "Apple",
                        name: "AirPods 3",
                        description: "Навушники оснащені технологією просторового аудіо, адаптивним еквалайзером та функцією оголошення сповіщень.\r\nМодель із провідною зарядкою кейсу: Apple AirPods 3 with Charging Case Запасні навушники для цієї моделі: правий (AirPods 3 Right), лівий (AirPods 3 Left)\r\nТретє покоління бездротових bluetooth-навушників від Apple із оригінальним зарядним кейсом, що підтримує використання бездротової магнітної зарядки MagSafe. Позиціонується як продукт верхньої цінової категорії 2022 модельного року, призначений для користувачів, які віддають перевагу гаджетам каліфорнійської компанії. Завдяки оптимізованому дизайну корпусу, навушники комфортно та впевнено сидять у вухах, не випадаючи навіть при різких рухах головою, стрибках та інших активностях.\r\n\r\nНезважаючи на очевидну зовнішню різницю з моделлю другого покоління, ці пристрої мають чимало спільного. В основі навушників Apple AirPods 3 with Wireless Charging Case також лежить спеціалізований процесор Apple H1. Але в цьому гаджеті він працює з удосконаленою мікропрограмою, яка забезпечує новинці на 15-25% кращу автономність, підвищує якість відтворення, а також забезпечує підтримку голосових команд Siri.\r\n\r\nЗавдяки технології просторового звучання Dolby Atmos ці навушники дозволяють по-новому почути навіть добре знайомі хіти. Функція динамічного відстеження точно реагує на кожен рух голови та створює тривимірне звучання, яке можна порівняти з прослуховуванням у справжньому концертному залі. Адаптивний еквалайзер враховує форму вуха та посадку, автоматично регулюючи параметри відтворення для отримання потужного та чистого звучання.",
                        shortDesc: "Навушники оснащені технологією просторового аудіо, адаптивним еквалайзером та функцією оголошення сповіщень.",
                        img: "/img/Headphones/AirPods 3/AirPods 3-1.jpg",
                        price: 5999,
                        isFavorite: false,
                        isAvailible: true,
                        imageUrls: new List<ProductImages>
                        {
                            new ProductImages {Name = "AirPods 3-1.jpg", ImageUrls = "/img/Headphones/AirPods 3/AirPods 3-1.jpg" },
                            new ProductImages {Name = "AirPods 3-2.jpg", ImageUrls = "/img/Headphones/AirPods 3/AirPods 3-2.jpg" },
                            new ProductImages {Name = "AirPods 3-3.jpg", ImageUrls = "/img/Headphones/AirPods 3/AirPods 3-3.jpg" },
                            new ProductImages {Name = "AirPods 3-4.jpg", ImageUrls = "/img/Headphones/AirPods 3/AirPods 3-4.jpg" },
                            new ProductImages {Name = "AirPods 3-5.jpg", ImageUrls = "/img/Headphones/AirPods 3/AirPods 3-5.jpg" }
                        },
                        categoryId: 1,
                        category: Categories["Headphones"]
                        ),
                     new Product(
                        productType: "Speakers",
                        brand: "JBL",
                        name: "Charge 5",
                        description: "Захист від вологи за стандартом IP67. Тривала автономність. JBL PartyBoost — бездротове з'єднання з іншими колонками, що підтримують цю функцію",
                        shortDesc: "Захист від вологи за стандартом IP67.",
                        img: "/img/Speakers/Charge 5/Charge 5-1.jpg",
                        price: 5150,
                        isFavorite: false,
                        isAvailible: true,
                        imageUrls: new List<ProductImages>
                        {
                            new ProductImages {Name = "Charge 5-1.jpg", ImageUrls = "/img/Speakers/Charge 5/Charge 5-1.jpg" },
                            new ProductImages {Name = "Charge 5-2.jpg", ImageUrls = "/img/Speakers/Charge 5/Charge 5-2.jpg" },
                            new ProductImages {Name = "Charge 5-3.jpg", ImageUrls = "/img/Speakers/Charge 5/Charge 5-3.jpg" },
                            new ProductImages {Name = "Charge 5-4.jpg", ImageUrls = "/img/Speakers/Charge 5/Charge 5-4.jpg" },
                            new ProductImages {Name = "Charge 5-5.jpg", ImageUrls = "/img/Speakers/Charge 5/Charge 5-5.jpg" }
                        },
                        categoryId: 2,
                        category: Categories["Speakers"]
                        ),
                     new Product(
                        productType: "Speakers",
                        brand: "JBL",
                        name: "Charge 4",
                        description: "Вологозахист за стандартом IPX7. Функція Power Bank'а. Тривала автономність. JBL Connect — бездротове з'єднання з іншими колонками, що підтримують цю функцію\r\nКомпактна і вологозахищена акустична система з бездротовим підключенням, функцією універсальної мобільної батареї і вбудованим літій-іонним акумулятором високої ємності. Позиціонується як продукт верхньої частини середньої цінової категорії 2019-го модельного року. Від популярної моделі JBL Charge 3 відрізняється підвищеною вихідною потужністю (до 30 Вт) і збільшеною ємністю інтегрованого акумулятора (7500 мАгод), який тепер здатний забезпечувати до 20 год автономної роботи при середньому рівні гучності.\r\n\r\nМобільна акустична система JBL Charge 4 здатна впевнено озвучувати приміщення площею до 25 кв. м. і допоможе організувати невелику дискотеку під відкритим небом. Для підключення пристрою до джерела звуку застосовується енергоефективний бездротовий інтерфейс bluetooth 4.2, здатний стабільно функціонувати на відстані до 10 м. Завдяки роз'єму лінійного входу AUX IN можна працювати і з аналоговими з'єднаннями.\r\n\r\nФірмовий, насичений басами звук JBL створює один активний акустичний випромінювач і два пасивних радіатора. Виробник гарантує відтворення частотного діапазону від 60 Гц до 20 кГц, чого цілком достатньо для абсолютної більшості музичних жанрів, причому особливо добре звучить електронна танцювальна музика та хіп-хоп. Завдяки додатковому роз'єму USB Type-C колонка може виступати в ролі зарядного пристрою для інших гаджетів.",
                        shortDesc: "Вологозахист за стандартом IPX7. Функція Power Bank'а. Тривала автономність. JBL Connect — бездротове з'єднання з іншими колонками, що підтримують цю функцію",
                        img: "/img/Speakers/Charge 4/Charge 4-1.jpg",
                        price: 4250,
                        isFavorite: false,
                        isAvailible: true,
                        imageUrls: new List<ProductImages>
                        {
                            new ProductImages {Name = "Charge 4-1.jpg", ImageUrls = "/img/Speakers/Charge 4/Charge 4-1.jpg" },
                            new ProductImages {Name = "Charge 4-2.jpg", ImageUrls = "/img/Speakers/Charge 4/Charge 4-2.jpg" },
                            new ProductImages {Name = "Charge 4-3.jpg", ImageUrls = "/img/Speakers/Charge 4/Charge 4-3.jpg" },
                            new ProductImages {Name = "Charge 4-4.jpg", ImageUrls = "/img/Speakers/Charge 4/Charge 4-4.jpg" },
                            new ProductImages {Name = "Charge 4-5.jpg", ImageUrls = "/img/Speakers/Charge 4/Charge 4-5.jpg" }
                        },
                        categoryId: 2,
                        category: Categories["Speakers"]
                        ),
                    new Product(
                        productType: "Speakers",
                        brand: "JBL",
                        name: "Xtreme 2",
                        description: "Захист від вологи. Підтримка Multiroom. Ємний акумулятор. Велика кількість роз'ємів. Функція Power Bank'а. Можливість підключення одночасно до трьох пристроїв.\r\nМобільна акустична система високої потужності з бездротовим bluetooth-підключенням, функцією спікерфона і відмінною автономністю. Позиціонується як продукт вищої цінової категорії з розширеною функціональністю. Призначена для озвучування великих приміщень і відкритих майданчиків значної площі. Підтримує фірмову технологію JBL Connect+, яка забезпечує бездротове об'єднання кількох подібних колонок в єдину акустичну систему.\r\n\r\nМає стильний і міцний гумово-пластиковий корпус, надійно захищений від попадання води за стандартом IPX7. Дає якісне, з характерним басовим акцентом звучання, що охоплює частотний діапазон від 55 Гц до 20000 Гц. Мобільна акустична система JBL Xtreme 2 забезпечує високу вихідну потужність (до 40 Вт) і обладнана значним літій-полімерним акумулятором ємністю 10000 мАгод. Така батарея забезпечує до 15 годин автономного звучання.\r\n\r\nКрім цього пристрій може виконувати функцію універсальної мобільної батареї і заряджати інші гаджети. Спікерфон колонки підтримує технологію луно- і шумозаглушення, тому зв'язок під час викликів буде залишатися чистим навіть при складному аудіооточенні. Для синхронізації з джерелом звуку (смартфоном, планшетом, ноутбуком) використовується енергоефективний інтерфейс bluetooth 4.2, що працює в радіусі до 10 м. Колонка важить 2,3 кг, для її перенесення на корпусі передбачені спеціальні металеві петлі.",
                        shortDesc: "Захист від вологи. Підтримка Multiroom. Ємний акумулятор. Велика кількість роз'ємів. Функція Power Bank'а. Можливість підключення одночасно до трьох пристроїв.",
                        img: "/img/Speakers/Xtreme 2/Xtreme 2-1.jpg",
                        price: 6750,
                        isFavorite: true,
                        isAvailible: true,
                        imageUrls: new List<ProductImages>
                        {
                            new ProductImages {Name = "Xtreme 2-1.jpg", ImageUrls = "/img/Speakers/Xtreme 2/Xtreme 2-1.jpg" },
                            new ProductImages {Name = "Xtreme 2-2.jpg", ImageUrls = "/img/Speakers/Xtreme 2/Xtreme 2-2.jpg" },
                            new ProductImages {Name = "Xtreme 2-3.jpg", ImageUrls = "/img/Speakers/Xtreme 2/Xtreme 2-3.jpg" },
                            new ProductImages {Name = "Xtreme 2-4.jpg", ImageUrls = "/img/Speakers/Xtreme 2/Xtreme 2-4.jpg" },
                            new ProductImages {Name = "Xtreme 2-5.jpg", ImageUrls = "/img/Speakers/Xtreme 2/Xtreme 2-5.jpg" }
                        },
                        categoryId: 2,
                        category: Categories["Speakers"]
                        )
                    );
            }

            context.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category (productType: "Headphones", description: "Headphones description text..."),
                        new Category (productType: "Speakers", description: "Speakers description text..."),
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category elem in list)
                    {
                        category.Add(elem.ProductType, elem);
                    }
                }
                return category;
            }
        }


    }
}
