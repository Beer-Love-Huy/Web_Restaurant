CREATE Database menu_service;
use menu_service;

-- Tạo bảng food_type
create table FoodType(
	IdFoodType int primary key auto_increment,
    NameFoodType varchar(50) not null unique
);

-- Chèn dữ liệu vào bảng food_type
insert into FoodType (NameFoodType)
values ('khai_vi'), ('mon_chinh'), ('mon_phu'), ('trang_mieng'), ('do_uong');


-- Tạo bảng food
create table Food(
	IdFood int primary key auto_increment,
	NameFood varchar(100) not null unique,
    PriceFood DECIMAL(10, 2) NOT NULL,
    ImgFood varchar(255) null,
    IdFoodType int,
    constraint fk_food_type foreign key(IdFoodType) references FoodType(IdFoodType)
);

-- Chèn dữ liệu vào bảng food
insert into Food(NameFood, PriceFood, ImgFood, IdFoodType)
values ('caprese_salad', 1000,'', 1), ('Pasta', 2000,'', 2), ('Carpaccio', 3000,'', 3), ('kem_gelato', 4000,'', 4), ('Prosecco', 5000,'', 5);
insert into Food(NameFood, PriceFood, ImgFood, IdFoodType)
values ('test1', 1000,'', 1), ('test2', 2000,'', 2), ('test3', 3000,'', 3), ('test4', 4000,'', 4), ('test5', 5000,'', 5);

select * from food