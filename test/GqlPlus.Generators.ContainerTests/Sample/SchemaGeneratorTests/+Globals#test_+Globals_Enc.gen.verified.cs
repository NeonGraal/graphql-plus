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

  internal static testCtgrDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpEncoder : IEncoder<ItestCtgrOutpObject>
{
  public Structured Encode(ItestCtgrOutpObject input)
    => Structured.Empty();

  internal static testCtgrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpDescrEncoder : IEncoder<ItestCtgrOutpDescrObject>
{
  public Structured Encode(ItestCtgrOutpDescrObject input)
    => Structured.Empty();

  internal static testCtgrOutpDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpDictEncoder : IEncoder<ItestCtgrOutpDictObject>
{
  public Structured Encode(ItestCtgrOutpDictObject input)
    => Structured.Empty();

  internal static testCtgrOutpDictEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpListEncoder : IEncoder<ItestCtgrOutpListObject>
{
  public Structured Encode(ItestCtgrOutpListObject input)
    => Structured.Empty();

  internal static testCtgrOutpListEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpOptlEncoder : IEncoder<ItestCtgrOutpOptlObject>
{
  public Structured Encode(ItestCtgrOutpOptlObject input)
    => Structured.Empty();

  internal static testCtgrOutpOptlEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrEncoder : IEncoder<ItestDescrObject>
{
  public Structured Encode(ItestDescrObject input)
    => Structured.Empty();

  internal static testDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrBcksEncoder : IEncoder<ItestDescrBcksObject>
{
  public Structured Encode(ItestDescrBcksObject input)
    => Structured.Empty();

  internal static testDescrBcksEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrBtwnEncoder : IEncoder<ItestDescrBtwnObject>
{
  public Structured Encode(ItestDescrBtwnObject input)
    => Structured.Empty();

  internal static testDescrBtwnEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrCmplEncoder : IEncoder<ItestDescrCmplObject>
{
  public Structured Encode(ItestDescrCmplObject input)
    => Structured.Empty();

  internal static testDescrCmplEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrDblEncoder : IEncoder<ItestDescrDblObject>
{
  public Structured Encode(ItestDescrDblObject input)
    => Structured.Empty();

  internal static testDescrDblEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrSnglEncoder : IEncoder<ItestDescrSnglObject>
{
  public Structured Encode(ItestDescrSnglObject input)
    => Structured.Empty();

  internal static testDescrSnglEncoder Factory(IEncoderRepository _) => new();
}

internal class testDscrsEncoder : IEncoder<ItestDscrsObject>
{
  public Structured Encode(ItestDscrsObject input)
    => Structured.Empty();

  internal static testDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprCtgrEncoder : IEncoder<ItestCatOprCtgrObject>
{
  public Structured Encode(ItestCatOprCtgrObject input)
    => Structured.Empty();

  internal static testCatOprCtgrEncoder Factory(IEncoderRepository _) => new();
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

  internal static testCatOprTypeEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprTypeEncoder : IEncoder<ItestAddrOprTypeObject>
{
  public Structured Encode(ItestAddrOprTypeObject input)
    => Structured.Empty()
      .Add("street", input.Street)
      .Add("city", input.City)
      .Add("country", input.Country);

  internal static testAddrOprTypeEncoder Factory(IEncoderRepository _) => new();
}

internal static class test__GlobalsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__GlobalsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrDscrsObject>(testCtgrDscrsEncoder.Factory)
      .AddEncoder<ItestCtgrOutpObject>(testCtgrOutpEncoder.Factory)
      .AddEncoder<ItestCtgrOutpDescrObject>(testCtgrOutpDescrEncoder.Factory)
      .AddEncoder<ItestCtgrOutpDictObject>(testCtgrOutpDictEncoder.Factory)
      .AddEncoder<ItestCtgrOutpListObject>(testCtgrOutpListEncoder.Factory)
      .AddEncoder<ItestCtgrOutpOptlObject>(testCtgrOutpOptlEncoder.Factory)
      .AddEncoder<ItestDescrObject>(testDescrEncoder.Factory)
      .AddEncoder<ItestDescrBcksObject>(testDescrBcksEncoder.Factory)
      .AddEncoder<ItestDescrBtwnObject>(testDescrBtwnEncoder.Factory)
      .AddEncoder<ItestDescrCmplObject>(testDescrCmplEncoder.Factory)
      .AddEncoder<ItestDescrDblObject>(testDescrDblEncoder.Factory)
      .AddEncoder<ItestDescrSnglObject>(testDescrSnglEncoder.Factory)
      .AddEncoder<ItestDscrsObject>(testDscrsEncoder.Factory)
      .AddEncoder<ItestCatOprCtgrObject>(testCatOprCtgrEncoder.Factory)
      .AddEncoder<ItestCatOprTypeObject>(testCatOprTypeEncoder.Factory)
      .AddEncoder<ItestAddrOprTypeObject>(testAddrOprTypeEncoder.Factory);
}
