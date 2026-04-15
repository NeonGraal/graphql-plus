//HintName: test_all_Enc.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidEncoder : IEncoder<ItestGuid>
{
  public Structured Encode(ItestGuid input)
    => new(input.Value);
}

internal class testOneEncoder : IEncoder<testOne>
{
  public Structured Encode(testOne input)
    => new(input.ToString(), "_One");
}

internal class testManyEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestMany>
{
  private readonly IEncoder<ItestGuid> _guid = encoders.EncoderFor<ItestGuid>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestMany input)
    => input.HasA<ItestGuid>() ? _guid.Encode(input.AsA<ItestGuid>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testFieldEncoder : IEncoder<ItestFieldObject>
{
  public Structured Encode(ItestFieldObject input)
    => Structured.Empty()
      .Add("strings", input.Strings.Encode());
}

internal class testAllEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAllObject>
{
  private readonly IEncoder<ItestField> _itestField = encoders.EncoderFor<ItestField>();
  public Structured Encode(ItestAllObject input)
    => Structured.Empty()
      .AddEncoded("items", input.Items(), _itestField);
}

internal static class test_allEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_allEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGuid>(_ => new testGuidEncoder())
      .AddEncoder<testOne>(_ => new testOneEncoder())
      .AddEncoder<ItestMany>(r => new testManyEncoder(r))
      .AddEncoder<ItestFieldObject>(_ => new testFieldEncoder())
      .AddEncoder<ItestAllObject>(r => new testAllEncoder(r));
}
