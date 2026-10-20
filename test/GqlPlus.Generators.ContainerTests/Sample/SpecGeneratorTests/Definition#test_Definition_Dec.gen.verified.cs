//HintName: test_Definition_Dec.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

internal class boolDecoder : NullDecoder<bool>
{
  public string false { get; set; } = default!;
  public string true { get; set; } = default!;

  internal static boolDecoder Factory(IDecoderRepository _) => new();
}

internal class GqlpNullDecoder : NullDecoder<GqlpNull>
{
  public string null { get; set; } = default!;

  internal static GqlpNullDecoder Factory(IDecoderRepository _) => new();
}

internal class GqlpUnitDecoder : NullDecoder<GqlpUnit>
{
  public string _ { get; set; } = default!;

  internal static GqlpUnitDecoder Factory(IDecoderRepository _) => new();
}

internal class voidDecoder : NullDecoder<void>
{

  internal static voidDecoder Factory(IDecoderRepository _) => new();
}

internal class decimalDecoder : NullDecoder<decimal>
{

  internal static decimalDecoder Factory(IDecoderRepository _) => new();
}

internal class stringDecoder : NullDecoder<string>
{

  internal static stringDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BasicDecoder : NullDecoder<Itest_Basic>
{
  public Boolean AsBoolean { get; set; } = default!;
  public Number AsNumber { get; set; } = default!;
  public String AsString { get; set; } = default!;
  public Unit AsUnit { get; set; } = default!;

  internal static test_BasicDecoder Factory(IDecoderRepository _) => new();
}

internal class test_InternalDecoder : NullDecoder<Itest_Internal>
{
  public Null AsNull { get; set; } = default!;
  public Void AsVoid { get; set; } = default!;

  internal static test_InternalDecoder Factory(IDecoderRepository _) => new();
}

internal class test_KeyDecoder : NullDecoder<Itest_Key>
{
  public _Basic As_Basic { get; set; } = default!;
  public _Internal As_Internal { get; set; } = default!;
  public _Simple As_Simple { get; set; } = default!;

  internal static test_KeyDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ObjectDecoder : NullDecoder<Itest_ObjectObject>
{

  internal static test_ObjectDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainDecoder : NullDecoder<Itest_Domain>
{

  internal static test_DomainDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DualDecoder : NullDecoder<Itest_DualObject>
{

  internal static test_DualDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumDecoder : NullDecoder<Itest_Enum>
{

  internal static test_EnumDecoder Factory(IDecoderRepository _) => new();
}

internal class test_InputDecoder : NullDecoder<Itest_InputObject>
{

  internal static test_InputDecoder Factory(IDecoderRepository _) => new();
}

internal class test_UnionDecoder : NullDecoder<Itest_Union>
{

  internal static test_UnionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_SimpleDecoder : NullDecoder<Itest_Simple>
{
  public _Enum As_Enum { get; set; } = default!;
  public _Domain As_Domain { get; set; } = default!;
  public _Union As_Union { get; set; } = default!;

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
