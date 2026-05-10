//HintName: test_Option_Enc.gen.cs
// Generated from {CurrentDirectory}Option.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Option;

internal class test_SettingEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_SettingObject>
{
  private readonly DeferOne<IEncoder<Itest_NamedObject>> _itest_Named = encoders.EncoderFor<Itest_NamedObject>();
  private readonly DeferOne<IEncoder<GqlpValue>> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_SettingObject input)
    => _itest_Named.I.Encode(input)
      .AddEncoded("value", input.Value, _gqlpValue.I);

  internal static test_SettingEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_OptionEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_OptionEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_SettingObject>(test_SettingEncoder.Factory);
}
