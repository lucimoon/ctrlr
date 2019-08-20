using System.Collections;

public interface ICommand
{
  ActivationType ActivationType { get; }
  void Execute();
}