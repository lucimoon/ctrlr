namespace tardigrage_alpha.Assets.Scripts
{
    public class StraightLine : TDCommand
    {
      public override void Execute()
      {
        controller.Move(Direction.left);
      }
    }
}