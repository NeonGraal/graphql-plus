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

internal static class test_DefinitionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DefinitionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<bool>(_ => new boolDecoder())
      .AddDecoder<GqlpNull>(_ => new GqlpNullDecoder())
      .AddDecoder<GqlpUnit>(_ => new GqlpUnitDecoder())
      .AddDecoder<void>(_ => new voidDecoder())
      .AddDecoder<decimal>(_ => new decimalDecoder())
      .AddDecoder<string>(_ => new stringDecoder())
      .AddDecoder<Itest_Basic>(r => new test_BasicDecoder(r))
      .AddDecoder<Itest_Internal>(r => new test_InternalDecoder(r))
      .AddDecoder<Itest_Key>(r => new test_KeyDecoder(r))
      .AddDecoder<Itest_ObjectObject>(_ => new test_ObjectDecoder())
      .AddDecoder<Itest_Domain>(_ => new test_DomainDecoder())
      .AddDecoder<Itest_DualObject>(_ => new test_DualDecoder())
      .AddDecoder<Itest_Enum>(_ => new test_EnumDecoder())
      .AddDecoder<Itest_InputObject>(_ => new test_InputDecoder())
      .AddDecoder<Itest_OutputObject>(_ => new test_OutputDecoder())
      .AddDecoder<Itest_Union>(_ => new test_UnionDecoder())
      .AddDecoder<Itest_Simple>(r => new test_SimpleDecoder(r));
}
