namespace DuckHunter.SystemApp.Render
{
    public struct RenderRegion
    {
        public int Width { get; }
        public int Height { get; }

        public RenderRegion(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
