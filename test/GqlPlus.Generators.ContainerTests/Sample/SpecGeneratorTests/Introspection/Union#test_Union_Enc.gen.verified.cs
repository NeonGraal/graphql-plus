//HintName: test_Union_Enc.gen.cs
// Generated from {CurrentDirectory}Union.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

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

internal static class test_UnionEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_UnionEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_UnionRefObject>(test_UnionRefEncoder.Factory)
      .AddEncoder<Itest_UnionMemberObject>(test_UnionMemberEncoder.Factory);
}
