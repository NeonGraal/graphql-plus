//HintName: test_Definition_Enc.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

internal class boolEncoder
{
  public string false { get; set; }
  public string true { get; set; }
}

internal class GqlpNullEncoder
{
  public string null { get; set; }
}

internal class GqlpUnitEncoder
{
  public string _ { get; set; }
}

internal class voidEncoder
{
}

internal class decimalEncoder
{
}

internal class stringEncoder
{
}

internal class test_BasicEncoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

internal class test_InternalEncoder
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

internal class test_KeyEncoder
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

internal class test_ObjectEncoder
{
}

internal class test_DomainEncoder
{
}

internal class test_DualEncoder
{
}

internal class test_EnumEncoder
{
}

internal class test_InputEncoder
{
}

internal class test_OutputEncoder
{
}

internal class test_UnionEncoder
{
}

internal class test_SimpleEncoder
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
