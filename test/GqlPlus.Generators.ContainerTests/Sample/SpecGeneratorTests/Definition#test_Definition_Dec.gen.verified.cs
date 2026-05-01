//HintName: test_Definition_Dec.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

internal class boolDecoder : IDecoder<bool?>
{
  public IMessages Decode(IValue input, out bool? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out bool value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode bool".AnError();
  }

  internal static boolDecoder Factory(IDecoderRepository _) => new();
}

internal class GqlpNullDecoder : IDecoder<GqlpNull?>
{
  public IMessages Decode(IValue input, out GqlpNull? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out GqlpNull value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode GqlpNull".AnError();
  }

  internal static GqlpNullDecoder Factory(IDecoderRepository _) => new();
}

internal class GqlpUnitDecoder : IDecoder<GqlpUnit?>
{
  public IMessages Decode(IValue input, out GqlpUnit? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out GqlpUnit value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode GqlpUnit".AnError();
  }

  internal static GqlpUnitDecoder Factory(IDecoderRepository _) => new();
}

internal class voidDecoder : IDecoder<void?>
{
  public IMessages Decode(IValue input, out void? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out void value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode void".AnError();
  }

  internal static voidDecoder Factory(IDecoderRepository _) => new();
}

internal class decimalDecoder : IDecoder<decimal>
{

  public IMessages Decode(IValue input, out decimal? output)
  {
    output = null;
    return Messages.New;
  }

  internal static decimalDecoder Factory(IDecoderRepository _) => new();
}

internal class stringDecoder : IDecoder<string>
{

  public IMessages Decode(IValue input, out string? output)
  {
    output = null;
    return Messages.New;
  }

  internal static stringDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BasicDecoder : IDecoder<Itest_Basic>
{
  public Boolean? AsBoolean { get; set; }
  public Number? AsNumber { get; set; }
  public String? AsString { get; set; }
  public Unit? AsUnit { get; set; }

  public IMessages Decode(IValue input, out Itest_Basic? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_BasicDecoder Factory(IDecoderRepository _) => new();
}

internal class test_InternalDecoder : IDecoder<Itest_Internal>
{
  public Null? AsNull { get; set; }
  public Void? AsVoid { get; set; }

  public IMessages Decode(IValue input, out Itest_Internal? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_InternalDecoder Factory(IDecoderRepository _) => new();
}

internal class test_KeyDecoder : IDecoder<Itest_Key>
{
  public _Basic? As_Basic { get; set; }
  public _Internal? As_Internal { get; set; }
  public _Simple? As_Simple { get; set; }

  public IMessages Decode(IValue input, out Itest_Key? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_KeyDecoder Factory(IDecoderRepository _) => new();
}

internal class test_ObjectDecoder : IDecoder<Itest_ObjectObject>
{

  public IMessages Decode(IValue input, out Itest_ObjectObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_ObjectDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainDecoder : IDecoder<Itest_Domain>
{

  public IMessages Decode(IValue input, out Itest_Domain? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DualDecoder : IDecoder<Itest_DualObject>
{

  public IMessages Decode(IValue input, out Itest_DualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DualDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumDecoder : IDecoder<Itest_Enum>
{

  public IMessages Decode(IValue input, out Itest_Enum? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_EnumDecoder Factory(IDecoderRepository _) => new();
}

internal class test_InputDecoder : IDecoder<Itest_InputObject>
{

  public IMessages Decode(IValue input, out Itest_InputObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_InputDecoder Factory(IDecoderRepository _) => new();
}

internal class test_UnionDecoder : IDecoder<Itest_Union>
{

  public IMessages Decode(IValue input, out Itest_Union? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_UnionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_SimpleDecoder : IDecoder<Itest_Simple>
{
  public _Enum? As_Enum { get; set; }
  public _Domain? As_Domain { get; set; }
  public _Union? As_Union { get; set; }

  public IMessages Decode(IValue input, out Itest_Simple? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_SimpleDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_DefinitionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DefinitionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<bool?>(boolDecoder.Factory)
      .AddDecoder<GqlpNull?>(GqlpNullDecoder.Factory)
      .AddDecoder<GqlpUnit?>(GqlpUnitDecoder.Factory)
      .AddDecoder<void?>(voidDecoder.Factory)
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
