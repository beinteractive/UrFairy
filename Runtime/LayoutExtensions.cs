namespace UrFairy
{
    public class LinearLayout
    {
        public float Size { get; set; }
        public float Spacing { get; set; }
        public int Count { get; set; }

        public float For(int i)
        {
            return (Size * Count + Spacing * (Count - 1)) * -0.5f + Size * 0.5f + (Size + Spacing) * i;
        }
    }
}