namespace Utils.EnumType
{
    // 이동 방향
    public enum Direction
    {
        Front,
        Back,
        Right,
        Left
    }

    // Customizing 파츠 종류
    public enum CustomizingParts
    {
        Body,
        Face,
        Hair,
        Top,
        Bottoms,
        Shoes
    }

    // 플레이어 상태
    public enum PlayerState
    {
        Idle,
        Move
    }

    // 손님 상태
    public enum CustomerState
    {
        Idle
    }

    // 아이템 카테고리 타입
    public enum ItemCategoryType
    {
        General,   // 일반식품
        Fresh,     // 신선식품
        Equipment  // 착용장비
    }

    // 아이템 카테고리
    public enum ItemCategory
    {
        Drink,              // 음료
        ProcessedFood,      // 가공식품
        HouseholdProducts,  // 생활용품
        SeaFood,            // 수산물
        LivestockProducts,  // 축산물
        Produce             // 농산물
    }

    // TileMap Layer
    public enum TileMapLayer
    {
        Ground, // 바닥
        Wall    // 벽
    }
}