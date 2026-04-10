//HintName: test_Definition_Dec.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

internal class boolDecoder
{
  public string false { get; set; }
  public string true { get; set; }
}

internal class GqlpNullDecoder
{
  public string null { get; set; }
}

internal class GqlpUnitDecoder
{
  public string _ { get; set; }
}

internal class voidDecoder
{
}

internal class decimalDecoder
{
}

internal class stringDecoder
{
}

internal class test_BasicDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }
}

internal class test_InternalDecoder
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }
}

internal class test_KeyDecoder
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }
}

internal class test_ObjectDecoder
{
}

internal class test_DomainDecoder
{
}

internal class test_DualDecoder
{
}

internal class test_EnumDecoder
{
}

internal class test_InputDecoder
{
}

internal class test_OutputDecoder
{
}

internal class test_UnionDecoder
{
}

internal class test_SimpleDecoder
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }
}
