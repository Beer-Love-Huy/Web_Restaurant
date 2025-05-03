namespace MenuAPI.Validators
{
    public class ValidatorMessages
    {
        // IdFoodType
        public const string IdFoodTypeNotemptyMessage = "IdFoodType không được để trống";
        public const string IdFoodTypeGreaterThanMessage = "IdFoodType phải lớn hơn 0";

        // NameFoodType
        public const string NameFoodTypeNotemptyMessage = "Tên loại món ăn không được để trống";
        public const string NameFoodTypeMaxLengthMessage = "Tên loại món ăn có tối đa 100 kí tự";
        public const string NameFoodTypeMinLengthMessage = "Tên loại món ăn có ít nhất 5 kí tự";

        // IdFood
        public const string IdFoodNotemptyMessage = "IdFood không được để trống";
        public const string IdFoodGreaterThanMessage = "IdFood phải lớn hơn 0";

        // NameFood
        public const string NameFoodNotemptyMessage = "Tên món ăn không được để trống";

        // PriceFood
        public const string PriceFoodNotemptyMessage = "Giá món ăn không được để trống";
        public const string PriceFoodGreaterThanMessage = "Giá món ăn phải lớn hơn 0";

        // ImgFood
        public const string ImgFoodMaxLengthMessage = "Url của img có tối đa 255 kí tự";
    }
}
