namespace Packt.Shared;

public class Animal
{
  public void SpeakBetter()
  {
    WriteLine("Wooooooooof...");
  }

  [Coder("Mark Price", "22 June 2024")]
  [Coder("Johnni Rasmussen", "13 July 2024")]
  [Obsolete($"use {nameof(SpeakBetter)} instead.")]
  public void Speak()
  {
    WriteLine("Woof...");
  }
}
