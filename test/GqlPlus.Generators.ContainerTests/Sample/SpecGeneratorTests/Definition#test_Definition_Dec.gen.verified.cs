//HintName: test_Definition_Dec.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

internal class boolDecoder
{
  public string false { get; set; }
  public string true { get; set; }

  internal static boolDecoder Factory(IDecoderRepository _) => new();
}

internal class GqlpNullDecoder
{
  public string null { get; set; }

  internal static GqlpNullDecoder Factory(IDecoderRepository _) => new();
}

internal class GqlpUnitDecoder
{
  public string _ { get; set; }

  internal static GqlpUnitDecoder Factory(IDecoderRepository _) => new();
}

internal class voidDecoder
{

  internal static voidDecoder Factory(IDecoderRepository _) => new();
}

internal class decimalDecoder
{

  internal static decimalDecoder Factory(IDecoderRepository _) => new();
}

internal class stringDecoder
{

  internal static stringDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BasicDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
  public Unit AsUnit { get; set; }

  internal static test_BasicDecoder Factory(IDecoderRepository _) => new();
}

internal class test_InternalDecoder
{
  public Null AsNull { get; set; }
  public Void AsVoid { get; set; }

  internal static test_InternalDecoder Factory(IDecoderRepository _) => new();
}

internal class test_KeyDecoder
{
  public _Basic As_Basic { get; set; }
  public _Internal As_Internal { get; set; }
  public _Simple As_Simple { get; set; }

  internal static test_KeyDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ObjectDecoder
{

  internal static test_ObjectDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainDecoder
{

  internal static test_DomainDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DualDecoder
{

  internal static test_DualDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumDecoder
{

  internal static test_EnumDecoder Factory(IDecoderRepository _) => new();
}

internal class test_InputDecoder
{

  internal static test_InputDecoder Factory(IDecoderRepository _) => new();
}

internal class test_UnionDecoder
{

  internal static test_UnionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_SimpleDecoder
{
  public _Enum As_Enum { get; set; }
  public _Domain As_Domain { get; set; }
  public _Union As_Union { get; set; }

  internal static test_SimpleDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_DefinitionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DefinitionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<bool>(boolDecoder.Factory)
      .AddDecoder<GqlpNull>(GqlpNullDecoder.Factory)
      .AddDecoder<GqlpUnit>(GqlpUnitDecoder.Factory)
      .AddDecoder<void>(voidDecoder.Factory)
      .AddDecoder<decimal>(decimalDecoder.Factory)
      .AddDecoder<string>(stringDecoder.Factory)
      .AddDecoder<Itest_Basic>(test_BasicDecoder.Factory)
      .AddDecoder<Itest_Internal>(test_InternalDecoder.Factory)
      .AddDecoder<Itest_Key>(test_KeyDecoder.Factory)
      .AddDecoder<Itest_ObjectObject>(test_ObjectDecoder.Factory)
      .AddDecoder<Itest_Domain>(test_DomainDecoder.Factory)
      .AddDecoder<Itest_DualObject>(test_DualDecoder.Factory)
      .AddDecoder<Itest_Enum>(test_EnumDecoder.Factory)
      .AddDecoder<Itest_InputObject>(test_InputDecoder.Factory)
      .AddDecoder<Itest_Union>(test_UnionDecoder.Factory)
      .AddDecoder<Itest_Simple>(test_SimpleDecoder.Factory);
}
