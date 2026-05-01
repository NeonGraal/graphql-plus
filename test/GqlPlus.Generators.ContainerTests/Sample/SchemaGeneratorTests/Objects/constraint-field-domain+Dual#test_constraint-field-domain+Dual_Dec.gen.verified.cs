//HintName: test_constraint-field-domain+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Dual;

internal class testCnstFieldDmnDualDecoder : IDecoder<ItestCnstFieldDmnDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldDmnDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDmnDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomCnstFieldDmnDualDecoder : IDecoder<ItestDomCnstFieldDmnDual>
{

  public IMessages Decode(IValue input, out ItestDomCnstFieldDmnDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstFieldDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_domain_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_domain_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDmnDualObject>(testCnstFieldDmnDualDecoder.Factory)
      .AddDecoder<ItestDomCnstFieldDmnDual>(testDomCnstFieldDmnDualDecoder.Factory);
}
