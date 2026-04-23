//HintName: test_+Merges_Enc.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testCtgrEncoder : IEncoder<ItestCtgrObject>
{
  public Structured Encode(ItestCtgrObject input)
    => Structured.Empty();

  internal static testCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrAliasEncoder : IEncoder<ItestCtgrAliasObject>
{
  public Structured Encode(ItestCtgrAliasObject input)
    => Structured.Empty();

  internal static testCtgrAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrDescrEncoder : IEncoder<ItestCtgrDescrObject>
{
  public Structured Encode(ItestCtgrDescrObject input)
    => Structured.Empty();

  internal static testCtgrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrModEncoder : IEncoder<ItestCtgrModObject>
{
  public Structured Encode(ItestCtgrModObject input)
    => Structured.Empty();

  internal static testCtgrModEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamEncoder : IEncoder<ItestInDrctParamObject>
{
  public Structured Encode(ItestInDrctParamObject input)
    => Structured.Empty();

  internal static testInDrctParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => input.Value!.Encode();

  internal static testDmnAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => input.Value!.Encode();

  internal static testDmnBoolEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public Structured Encode(ItestDmnBoolDiff input)
    => input.Value!.Encode();

  internal static testDmnBoolDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public Structured Encode(ItestDmnBoolSame input)
    => input.Value!.Encode();

  internal static testDmnBoolSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => input.Value?.EncodeEnum("bool")!;

  internal static testDmnEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public Structured Encode(ItestDmnEnumSame input)
    => input.Value?.EncodeEnum("bool")!;

  internal static testDmnEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public Structured Encode(ItestDmnNmbr input)
    => input.Value!.Encode();

  internal static testDmnNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public Structured Encode(ItestDmnNmbrDiff input)
    => input.Value!.Encode();

  internal static testDmnNmbrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public Structured Encode(ItestDmnNmbrSame input)
    => input.Value!.Encode();

  internal static testDmnNmbrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public Structured Encode(ItestDmnStr input)
    => input.Value!.Encode();

  internal static testDmnStrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public Structured Encode(ItestDmnStrDiff input)
    => input.Value!.Encode();

  internal static testDmnStrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public Structured Encode(ItestDmnStrSame input)
    => input.Value!.Encode();

  internal static testDmnStrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => input.EncodeEnum("EnumAlias");

  internal static testEnumAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public Structured Encode(testEnumDiff input)
    => input.EncodeEnum("EnumDiff");

  internal static testEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public Structured Encode(testEnumSame input)
    => input.EncodeEnum("EnumSame");

  internal static testEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public Structured Encode(testEnumSamePrnt input)
    => input.EncodeEnum("EnumSamePrnt");

  internal static testEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public Structured Encode(testPrntEnumSamePrnt input)
    => input.EncodeEnum("PrntEnumSamePrnt");

  internal static testPrntEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public Structured Encode(testEnumValueAlias input)
    => input.EncodeEnum("EnumValueAlias");

  internal static testEnumValueAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public Structured Encode(ItestObjDualObject input)
    => Structured.Empty();

  internal static testObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjInpEncoder : IEncoder<ItestObjInpObject>
{
  public Structured Encode(ItestObjInpObject input)
    => Structured.Empty();

  internal static testObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjOutpEncoder : IEncoder<ItestObjOutpObject>
{
  public Structured Encode(ItestObjOutpObject input)
    => Structured.Empty();

  internal static testObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasDualEncoder : IEncoder<ItestObjAliasDualObject>
{
  public Structured Encode(ItestObjAliasDualObject input)
    => Structured.Empty();

  internal static testObjAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasInpEncoder : IEncoder<ItestObjAliasInpObject>
{
  public Structured Encode(ItestObjAliasInpObject input)
    => Structured.Empty();

  internal static testObjAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasOutpEncoder : IEncoder<ItestObjAliasOutpObject>
{
  public Structured Encode(ItestObjAliasOutpObject input)
    => Structured.Empty();

  internal static testObjAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public Structured Encode(ItestObjAltDualObject input)
    => Structured.Empty();

  internal static testObjAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public Structured Encode(ItestObjAltDualTypeObject input)
    => Structured.Empty();

  internal static testObjAltDualTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpEncoder : IEncoder<ItestObjAltInpObject>
{
  public Structured Encode(ItestObjAltInpObject input)
    => Structured.Empty();

  internal static testObjAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpTypeEncoder : IEncoder<ItestObjAltInpTypeObject>
{
  public Structured Encode(ItestObjAltInpTypeObject input)
    => Structured.Empty();

  internal static testObjAltInpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public Structured Encode(ItestObjAltOutpObject input)
    => Structured.Empty();

  internal static testObjAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public Structured Encode(ItestObjAltOutpTypeObject input)
    => Structured.Empty();

  internal static testObjAltOutpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumDualEncoder : IEncoder<ItestObjAltEnumDualObject>
{
  public Structured Encode(ItestObjAltEnumDualObject input)
    => Structured.Empty();

  internal static testObjAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumInpEncoder : IEncoder<ItestObjAltEnumInpObject>
{
  public Structured Encode(ItestObjAltEnumInpObject input)
    => Structured.Empty();

  internal static testObjAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumOutpEncoder : IEncoder<ItestObjAltEnumOutpObject>
{
  public Structured Encode(ItestObjAltEnumOutpObject input)
    => Structured.Empty();

  internal static testObjAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjCnstDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjCnstInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjCnstOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldDualObject>
{
  private readonly IEncoder<ItestFldObjFieldDual> _itestFldObjFieldDual = encoders.EncoderFor<ItestFldObjFieldDual>();
  public Structured Encode(ItestObjFieldDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldDual);

  internal static testObjFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldDualEncoder : IEncoder<ItestFldObjFieldDualObject>
{
  public Structured Encode(ItestFldObjFieldDualObject input)
    => Structured.Empty();

  internal static testFldObjFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldInpObject>
{
  private readonly IEncoder<ItestFldObjFieldInp> _itestFldObjFieldInp = encoders.EncoderFor<ItestFldObjFieldInp>();
  public Structured Encode(ItestObjFieldInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldInp);

  internal static testObjFieldInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldInpEncoder : IEncoder<ItestFldObjFieldInpObject>
{
  public Structured Encode(ItestFldObjFieldInpObject input)
    => Structured.Empty();

  internal static testFldObjFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldOutp> _itestFldObjFieldOutp = encoders.EncoderFor<ItestFldObjFieldOutp>();
  public Structured Encode(ItestObjFieldOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldOutp);

  internal static testObjFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldOutpEncoder : IEncoder<ItestFldObjFieldOutpObject>
{
  public Structured Encode(ItestFldObjFieldOutpObject input)
    => Structured.Empty();

  internal static testFldObjFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public Structured Encode(ItestObjFieldAliasDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);

  internal static testObjFieldAliasDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public Structured Encode(ItestFldObjFieldAliasDualObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasInpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasInp> _itestFldObjFieldAliasInp = encoders.EncoderFor<ItestFldObjFieldAliasInp>();
  public Structured Encode(ItestObjFieldAliasInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasInp);

  internal static testObjFieldAliasInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasInpEncoder : IEncoder<ItestFldObjFieldAliasInpObject>
{
  public Structured Encode(ItestFldObjFieldAliasInpObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasOutp> _itestFldObjFieldAliasOutp = encoders.EncoderFor<ItestFldObjFieldAliasOutp>();
  public Structured Encode(ItestObjFieldAliasOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasOutp);

  internal static testObjFieldAliasOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasOutpEncoder : IEncoder<ItestFldObjFieldAliasOutpObject>
{
  public Structured Encode(ItestFldObjFieldAliasOutpObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualEncoder : IEncoder<ItestObjFieldEnumAliasDualObject>
{
  public Structured Encode(ItestObjFieldEnumAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpEncoder : IEncoder<ItestObjFieldEnumAliasInpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public Structured Encode(ItestObjFieldEnumValueDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueInpEncoder : IEncoder<ItestObjFieldEnumValueInpObject>
{
  public Structured Encode(ItestObjFieldEnumValueInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public Structured Encode(ItestObjFieldEnumValueOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public Structured Encode(ItestObjFieldTypeAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpEncoder : IEncoder<ItestObjFieldTypeAliasInpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjParamDualEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDualObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamDualObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamInpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamInpObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamInpObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamOutpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamOutpObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamOutpObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamDupDualEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupDualObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupDualObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjParamDupInpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupInpObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupInpObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjParamDupOutpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupOutpObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupOutpObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntDualObject>
{
  private readonly IEncoder<ItestRefObjPrntDualObject> _itestRefObjPrntDual = encoders.EncoderFor<ItestRefObjPrntDualObject>();
  public Structured Encode(ItestObjPrntDualObject input)
    => _itestRefObjPrntDual.Encode(input);

  internal static testObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntDualEncoder : IEncoder<ItestRefObjPrntDualObject>
{
  public Structured Encode(ItestRefObjPrntDualObject input)
    => Structured.Empty();

  internal static testRefObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntInpObject>
{
  private readonly IEncoder<ItestRefObjPrntInpObject> _itestRefObjPrntInp = encoders.EncoderFor<ItestRefObjPrntInpObject>();
  public Structured Encode(ItestObjPrntInpObject input)
    => _itestRefObjPrntInp.Encode(input);

  internal static testObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntInpEncoder : IEncoder<ItestRefObjPrntInpObject>
{
  public Structured Encode(ItestRefObjPrntInpObject input)
    => Structured.Empty();

  internal static testRefObjPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefObjPrntOutpObject> _itestRefObjPrntOutp = encoders.EncoderFor<ItestRefObjPrntOutpObject>();
  public Structured Encode(ItestObjPrntOutpObject input)
    => _itestRefObjPrntOutp.Encode(input);

  internal static testObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntOutpEncoder : IEncoder<ItestRefObjPrntOutpObject>
{
  public Structured Encode(ItestRefObjPrntOutpObject input)
    => Structured.Empty();

  internal static testRefObjPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly IEncoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public Structured Encode(ItestOutpFieldParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpFieldParam);

  internal static testOutpFieldParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testOutpFieldParam1Encoder : IEncoder<ItestOutpFieldParam1Object>
{
  public Structured Encode(ItestOutpFieldParam1Object input)
    => Structured.Empty();

  internal static testOutpFieldParam1Encoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParam2Encoder : IEncoder<ItestOutpFieldParam2Object>
{
  public Structured Encode(ItestOutpFieldParam2Object input)
    => Structured.Empty();

  internal static testOutpFieldParam2Encoder Factory(IEncoderRepository _) => new();
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public Structured Encode(ItestFldOutpFieldParamObject input)
    => Structured.Empty();

  internal static testFldOutpFieldParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testUnionAliasEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionAlias>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionAlias input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionAliasEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionDiffEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDiff>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDiff input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionDiffEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionSameEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSame>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSame input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();

  internal static testUnionSameEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSamePrnt>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();

  internal static testUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();

  internal static testPrntUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test__MergesEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__MergesEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrObject>(testCtgrEncoder.Factory)
      .AddEncoder<ItestCtgrAliasObject>(testCtgrAliasEncoder.Factory)
      .AddEncoder<ItestCtgrDescrObject>(testCtgrDescrEncoder.Factory)
      .AddEncoder<ItestCtgrModObject>(testCtgrModEncoder.Factory)
      .AddEncoder<ItestInDrctParamObject>(testInDrctParamEncoder.Factory)
      .AddEncoder<ItestDmnAlias>(testDmnAliasEncoder.Factory)
      .AddEncoder<ItestDmnBool>(testDmnBoolEncoder.Factory)
      .AddEncoder<ItestDmnBoolDiff>(testDmnBoolDiffEncoder.Factory)
      .AddEncoder<ItestDmnBoolSame>(testDmnBoolSameEncoder.Factory)
      .AddEncoder<ItestDmnEnumDiff>(testDmnEnumDiffEncoder.Factory)
      .AddEncoder<ItestDmnEnumSame>(testDmnEnumSameEncoder.Factory)
      .AddEncoder<ItestDmnNmbr>(testDmnNmbrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrDiff>(testDmnNmbrDiffEncoder.Factory)
      .AddEncoder<ItestDmnNmbrSame>(testDmnNmbrSameEncoder.Factory)
      .AddEncoder<ItestDmnStr>(testDmnStrEncoder.Factory)
      .AddEncoder<ItestDmnStrDiff>(testDmnStrDiffEncoder.Factory)
      .AddEncoder<ItestDmnStrSame>(testDmnStrSameEncoder.Factory)
      .AddEncoder<testEnumAlias>(testEnumAliasEncoder.Factory)
      .AddEncoder<testEnumDiff>(testEnumDiffEncoder.Factory)
      .AddEncoder<testEnumSame>(testEnumSameEncoder.Factory)
      .AddEncoder<testEnumSamePrnt>(testEnumSamePrntEncoder.Factory)
      .AddEncoder<testPrntEnumSamePrnt>(testPrntEnumSamePrntEncoder.Factory)
      .AddEncoder<testEnumValueAlias>(testEnumValueAliasEncoder.Factory)
      .AddEncoder<ItestObjDualObject>(testObjDualEncoder.Factory)
      .AddEncoder<ItestObjInpObject>(testObjInpEncoder.Factory)
      .AddEncoder<ItestObjOutpObject>(testObjOutpEncoder.Factory)
      .AddEncoder<ItestObjAliasDualObject>(testObjAliasDualEncoder.Factory)
      .AddEncoder<ItestObjAliasInpObject>(testObjAliasInpEncoder.Factory)
      .AddEncoder<ItestObjAliasOutpObject>(testObjAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjAltDualObject>(testObjAltDualEncoder.Factory)
      .AddEncoder<ItestObjAltDualTypeObject>(testObjAltDualTypeEncoder.Factory)
      .AddEncoder<ItestObjAltInpObject>(testObjAltInpEncoder.Factory)
      .AddEncoder<ItestObjAltInpTypeObject>(testObjAltInpTypeEncoder.Factory)
      .AddEncoder<ItestObjAltOutpObject>(testObjAltOutpEncoder.Factory)
      .AddEncoder<ItestObjAltOutpTypeObject>(testObjAltOutpTypeEncoder.Factory)
      .AddEncoder<ItestObjAltEnumDualObject>(testObjAltEnumDualEncoder.Factory)
      .AddEncoder<ItestObjAltEnumInpObject>(testObjAltEnumInpEncoder.Factory)
      .AddEncoder<ItestObjAltEnumOutpObject>(testObjAltEnumOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldDualObject>(testObjFieldDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldDualObject>(testFldObjFieldDualEncoder.Factory)
      .AddEncoder<ItestObjFieldInpObject>(testObjFieldInpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldInpObject>(testFldObjFieldInpEncoder.Factory)
      .AddEncoder<ItestObjFieldOutpObject>(testObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldOutpObject>(testFldObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasOutpObject>(testObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasOutpObject>(testFldObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasOutpObject>(testObjFieldEnumAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueOutpObject>(testObjFieldEnumValueOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasOutpObject>(testObjFieldTypeAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjPrntDualObject>(testObjPrntDualEncoder.Factory)
      .AddEncoder<ItestRefObjPrntDualObject>(testRefObjPrntDualEncoder.Factory)
      .AddEncoder<ItestObjPrntInpObject>(testObjPrntInpEncoder.Factory)
      .AddEncoder<ItestRefObjPrntInpObject>(testRefObjPrntInpEncoder.Factory)
      .AddEncoder<ItestObjPrntOutpObject>(testObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestRefObjPrntOutpObject>(testRefObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestOutpFieldParamObject>(testOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Encoder.Factory)
      .AddEncoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Encoder.Factory)
      .AddEncoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestUnionAlias>(testUnionAliasEncoder.Factory)
      .AddEncoder<ItestUnionDiff>(testUnionDiffEncoder.Factory)
      .AddEncoder<ItestUnionSame>(testUnionSameEncoder.Factory)
      .AddEncoder<ItestUnionSamePrnt>(testUnionSamePrntEncoder.Factory)
      .AddEncoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntEncoder.Factory);
}
