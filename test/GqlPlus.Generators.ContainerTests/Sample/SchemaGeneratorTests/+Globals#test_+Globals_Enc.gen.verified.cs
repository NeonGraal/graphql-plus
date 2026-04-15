//HintName: test_+Globals_Enc.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testCtgrDscrsEncoder : IEncoder<ItestCtgrDscrsObject>
{
  public Structured Encode(ItestCtgrDscrsObject input)
    => Structured.Empty();
}

internal class testCtgrOutpEncoder : IEncoder<ItestCtgrOutpObject>
{
  public Structured Encode(ItestCtgrOutpObject input)
    => Structured.Empty();
}

internal class testCtgrOutpDescrEncoder : IEncoder<ItestCtgrOutpDescrObject>
{
  public Structured Encode(ItestCtgrOutpDescrObject input)
    => Structured.Empty();
}

internal class testCtgrOutpDictEncoder : IEncoder<ItestCtgrOutpDictObject>
{
  public Structured Encode(ItestCtgrOutpDictObject input)
    => Structured.Empty();
}

internal class testCtgrOutpListEncoder : IEncoder<ItestCtgrOutpListObject>
{
  public Structured Encode(ItestCtgrOutpListObject input)
    => Structured.Empty();
}

internal class testCtgrOutpOptlEncoder : IEncoder<ItestCtgrOutpOptlObject>
{
  public Structured Encode(ItestCtgrOutpOptlObject input)
    => Structured.Empty();
}

internal class testDescrEncoder : IEncoder<ItestDescrObject>
{
  public Structured Encode(ItestDescrObject input)
    => Structured.Empty();
}

internal class testDescrBcksEncoder : IEncoder<ItestDescrBcksObject>
{
  public Structured Encode(ItestDescrBcksObject input)
    => Structured.Empty();
}

internal class testDescrBtwnEncoder : IEncoder<ItestDescrBtwnObject>
{
  public Structured Encode(ItestDescrBtwnObject input)
    => Structured.Empty();
}

internal class testDescrCmplEncoder : IEncoder<ItestDescrCmplObject>
{
  public Structured Encode(ItestDescrCmplObject input)
    => Structured.Empty();
}

internal class testDescrDblEncoder : IEncoder<ItestDescrDblObject>
{
  public Structured Encode(ItestDescrDblObject input)
    => Structured.Empty();
}

internal class testDescrSnglEncoder : IEncoder<ItestDescrSnglObject>
{
  public Structured Encode(ItestDescrSnglObject input)
    => Structured.Empty();
}

internal class testDscrsEncoder : IEncoder<ItestDscrsObject>
{
  public Structured Encode(ItestDscrsObject input)
    => Structured.Empty();
}

internal class testCatOprCtgrEncoder : IEncoder<ItestCatOprCtgrObject>
{
  public Structured Encode(ItestCatOprCtgrObject input)
    => Structured.Empty();
}

internal class testCatOprTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprTypeObject>
{
  private readonly IEncoder<ItestAddrOprType> _itestAddrOprType = encoders.EncoderFor<ItestAddrOprType>();
  public Structured Encode(ItestCatOprTypeObject input)
    => Structured.Empty()
      .Add("first", input.First)
      .Add("last", input.Last)
      .AddEncoded("address", input.Address, _itestAddrOprType);
}

internal class testAddrOprTypeEncoder : IEncoder<ItestAddrOprTypeObject>
{
  public Structured Encode(ItestAddrOprTypeObject input)
    => Structured.Empty()
      .Add("street", input.Street)
      .Add("city", input.City)
      .Add("country", input.Country);
}

internal static class test__GlobalsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__GlobalsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrDscrsObject>(_ => new testCtgrDscrsEncoder())
      .AddEncoder<ItestCtgrOutpObject>(_ => new testCtgrOutpEncoder())
      .AddEncoder<ItestCtgrOutpDescrObject>(_ => new testCtgrOutpDescrEncoder())
      .AddEncoder<ItestCtgrOutpDictObject>(_ => new testCtgrOutpDictEncoder())
      .AddEncoder<ItestCtgrOutpListObject>(_ => new testCtgrOutpListEncoder())
      .AddEncoder<ItestCtgrOutpOptlObject>(_ => new testCtgrOutpOptlEncoder())
      .AddEncoder<ItestDescrObject>(_ => new testDescrEncoder())
      .AddEncoder<ItestDescrBcksObject>(_ => new testDescrBcksEncoder())
      .AddEncoder<ItestDescrBtwnObject>(_ => new testDescrBtwnEncoder())
      .AddEncoder<ItestDescrCmplObject>(_ => new testDescrCmplEncoder())
      .AddEncoder<ItestDescrDblObject>(_ => new testDescrDblEncoder())
      .AddEncoder<ItestDescrSnglObject>(_ => new testDescrSnglEncoder())
      .AddEncoder<ItestDscrsObject>(_ => new testDscrsEncoder())
      .AddEncoder<ItestCatOprCtgrObject>(_ => new testCatOprCtgrEncoder())
      .AddEncoder<ItestCatOprTypeObject>(r => new testCatOprTypeEncoder(r))
      .AddEncoder<ItestAddrOprTypeObject>(_ => new testAddrOprTypeEncoder());
}
