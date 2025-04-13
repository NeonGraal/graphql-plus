//HintName: Model_Intro_Output.gen.cs
// Generated from Intro_Output.graphql+

/*
*/

namespace GqlTest.Model_Intro_Output;

public interface I_TypeOutput
{
}
public class Output_TypeOutput
{
}

public interface I_OutputBase
{
  _Identifier output { get; }
  _DualBase As_DualBase { get; }
}
public class Output_OutputBase
{
  public _Identifier output { get; set; }
  public _DualBase As_DualBase { get; set; }
}

public interface I_OutputField
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}
public class Output_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public interface I_OutputAlternate
{
  _Identifier output { get; }
}
public class Output_OutputAlternate
{
  public _Identifier output { get; set; }
}

public interface I_OutputTypeArg
{
  _Identifier output { get; }
  _Identifier label { get; }
}
public class Output_OutputTypeArg
{
  public _Identifier output { get; set; }
  public _Identifier label { get; set; }
}

public interface I_OutputEnum
{
  _Identifier field { get; }
  _Identifier label { get; }
}
public class Output_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
