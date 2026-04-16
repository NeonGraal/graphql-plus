//HintName: test_Enum_Enc.gen.cs
// Generated from {CurrentDirectory}Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

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

internal static class test_EnumEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_EnumEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_EnumLabelObject>(test_EnumLabelEncoder.Factory)
      .AddEncoder<Itest_EnumValueObject>(test_EnumValueEncoder.Factory);
}
