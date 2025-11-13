//HintName: test_Definition_Intf.gen.cs
// Generated from Definition.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Definition;

public interface ItestNumber
{
}

public interface ItestString
{
}

public interface Itest_Basic
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
  String AsString { get; }
  Unit AsUnit { get; }
}

public interface Itest_Internal
{
  Null AsNull { get; }
  Void AsVoid { get; }
}

public interface Itest_Key
{
  _Basic As_Basic { get; }
  _Internal As_Internal { get; }
  _Simple As_Simple { get; }
}

public interface Itest_Object
{
  public test_Object _Object { get; set; }
}

public interface Itest_ObjectField
{
}

public interface Itest_Domain
{
}

public interface Itest_Dual
{
  public test_Dual _Dual { get; set; }
}

public interface Itest_DualField
{
}

public interface Itest_Enum
{
}

public interface Itest_Input
{
  public test_Input _Input { get; set; }
}

public interface Itest_InputField
{
}

public interface Itest_Output
{
  public test_Output _Output { get; set; }
}

public interface Itest_OutputField
{
}

public interface Itest_Union
{
}

public interface Itest_Simple
{
  _Enum As_Enum { get; }
  _Domain As_Domain { get; }
  _Union As_Union { get; }
}
