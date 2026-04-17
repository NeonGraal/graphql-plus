//HintName: test_-Simple_Enc.gen.cs
// Generated from {CurrentDirectory}-Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class test_DomainKindEncoder : IEncoder<test_DomainKind>
{
  public Structured Encode(test_DomainKind input)
    => new(input.ToString(), "_DomainKind");

  internal static test_DomainKindEncoder Factory(IEncoderRepository _) => new();
}

internal class test_DomainRefEncoder<TDomainKind>(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRefObject<TDomainKind>>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<TDomainKind> _domainKind = encoders.EncoderFor<TDomainKind>();
  public Structured Encode(Itest_DomainRefObject<TDomainKind> input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("domainKind", input.DomainKind, _domainKind);
}

internal class test_BaseDomainEncoder<TDomainKind,TItem,TDomainItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>>
{
  private readonly IEncoder<Itest_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>> _itest_ParentType = encoders.EncoderFor<Itest_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>>();
  private readonly IEncoder<TDomainKind> _domainKind = encoders.EncoderFor<TDomainKind>();
  public Structured Encode(Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem> input)
    => _itest_ParentType.Encode(input)
      .AddEncoded("domainKind", input.DomainKind, _domainKind);
}

internal class test_BaseDomainItemEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_BaseDomainItemObject>
{
  private readonly IEncoder<Itest_DescribedObject> _itest_Described = encoders.EncoderFor<Itest_DescribedObject>();
  public Structured Encode(Itest_BaseDomainItemObject input)
    => _itest_Described.Encode(input)
      .Add("exclude", input.Exclude);

  internal static test_BaseDomainItemEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemEncoder<TItem>(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemObject<TItem>>
{
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_DomainItemObject<TItem> input)
    => Structured.Empty()
      .AddEncoded("domain", input.Domain, _itest_Name);
}

internal class test_DomainValueEncoder<TDomainKind,TValue>(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainValueObject<TDomainKind,TValue>>
{
  private readonly IEncoder<Itest_DomainRefObject<TDomainKind>> _itest_DomainRef = encoders.EncoderFor<Itest_DomainRefObject<TDomainKind>>();
  private readonly IEncoder<TValue> _value = encoders.EncoderFor<TValue>();
  public Structured Encode(Itest_DomainValueObject<TDomainKind,TValue> input)
    => _itest_DomainRef.Encode(input)
      .AddEncoded("value", input.Value, _value);
}

internal class test_BasicValueEncoder : IEncoder<Itest_BasicValueObject>
{
  public Structured Encode(Itest_BasicValueObject input)
    => Structured.Empty();

  internal static test_BasicValueEncoder Factory(IEncoderRepository _) => new();
}

internal class test_DomainTrueFalseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainTrueFalseObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainTrueFalseObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("value", input.Value);

  internal static test_DomainTrueFalseEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemTrueFalseEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemTrueFalseObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainTrueFalse>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainTrueFalse>>();
  public Structured Encode(Itest_DomainItemTrueFalseObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemTrueFalseEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainLabelObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  private readonly IEncoder<Itest_EnumValue> _itest_EnumValue = encoders.EncoderFor<Itest_EnumValue>();
  public Structured Encode(Itest_DomainLabelObject input)
    => _itest_BaseDomainItem.Encode(input)
      .AddEncoded("label", input.Label, _itest_EnumValue);

  internal static test_DomainLabelEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemLabelObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainLabel>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainLabel>>();
  public Structured Encode(Itest_DomainItemLabelObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemLabelEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainRangeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRangeObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainRangeObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("lower", input.Lower)
      .Add("upper", input.Upper);

  internal static test_DomainRangeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemRangeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemRangeObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainRange>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainRange>>();
  public Structured Encode(Itest_DomainItemRangeObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemRangeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainRegexEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainRegexObject>
{
  private readonly IEncoder<Itest_BaseDomainItemObject> _itest_BaseDomainItem = encoders.EncoderFor<Itest_BaseDomainItemObject>();
  public Structured Encode(Itest_DomainRegexObject input)
    => _itest_BaseDomainItem.Encode(input)
      .Add("pattern", input.Pattern);

  internal static test_DomainRegexEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_DomainItemRegexEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DomainItemRegexObject>
{
  private readonly IEncoder<Itest_DomainItemObject<Itest_DomainRegex>> _itest_DomainItem = encoders.EncoderFor<Itest_DomainItemObject<Itest_DomainRegex>>();
  public Structured Encode(Itest_DomainItemRegexObject input)
    => _itest_DomainItem.Encode(input);

  internal static test_DomainItemRegexEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_EnumLabelEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_EnumLabelObject>
{
  private readonly IEncoder<Itest_AliasedObject> _itest_Aliased = encoders.EncoderFor<Itest_AliasedObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_EnumLabelObject input)
    => _itest_Aliased.Encode(input)
      .AddEncoded("enumType", input.EnumType, _itest_Name);

  internal static test_EnumLabelEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_EnumValueEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_EnumValueObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_TypeKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<Itest_TypeKind>>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_EnumValueObject input)
    => _itest_TypeRef.Encode(input)
      .AddEncoded("label", input.Label, _itest_Name);

  internal static test_EnumValueEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_UnionRefEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_UnionRefObject>
{
  private readonly IEncoder<Itest_TypeRefObject<Itest_SimpleKind>> _itest_TypeRef = encoders.EncoderFor<Itest_TypeRefObject<Itest_SimpleKind>>();
  public Structured Encode(Itest_UnionRefObject input)
    => _itest_TypeRef.Encode(input);

  internal static test_UnionRefEncoder Factory(IEncoderRepository r) => new(r);
}

internal class test_UnionMemberEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_UnionMemberObject>
{
  private readonly IEncoder<Itest_UnionRefObject> _itest_UnionRef = encoders.EncoderFor<Itest_UnionRefObject>();
  private readonly IEncoder<Itest_Name> _itest_Name = encoders.EncoderFor<Itest_Name>();
  public Structured Encode(Itest_UnionMemberObject input)
    => _itest_UnionRef.Encode(input)
      .AddEncoded("union", input.Union, _itest_Name);

  internal static test_UnionMemberEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test__SimpleEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__SimpleEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<test_DomainKind>(test_DomainKindEncoder.Factory)
      .AddEncoder<Itest_BaseDomainItemObject>(test_BaseDomainItemEncoder.Factory)
      .AddEncoder<Itest_BasicValueObject>(test_BasicValueEncoder.Factory)
      .AddEncoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseEncoder.Factory)
      .AddEncoder<Itest_DomainItemTrueFalseObject>(test_DomainItemTrueFalseEncoder.Factory)
      .AddEncoder<Itest_DomainLabelObject>(test_DomainLabelEncoder.Factory)
      .AddEncoder<Itest_DomainItemLabelObject>(test_DomainItemLabelEncoder.Factory)
      .AddEncoder<Itest_DomainRangeObject>(test_DomainRangeEncoder.Factory)
      .AddEncoder<Itest_DomainItemRangeObject>(test_DomainItemRangeEncoder.Factory)
      .AddEncoder<Itest_DomainRegexObject>(test_DomainRegexEncoder.Factory)
      .AddEncoder<Itest_DomainItemRegexObject>(test_DomainItemRegexEncoder.Factory)
      .AddEncoder<Itest_EnumLabelObject>(test_EnumLabelEncoder.Factory)
      .AddEncoder<Itest_EnumValueObject>(test_EnumValueEncoder.Factory)
      .AddEncoder<Itest_UnionRefObject>(test_UnionRefEncoder.Factory)
      .AddEncoder<Itest_UnionMemberObject>(test_UnionMemberEncoder.Factory);
}
