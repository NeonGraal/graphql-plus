//HintName: test_+Merges_Enc.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => new(input.Value);

  internal static testDmnAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => new(input.Value);

  internal static testDmnBoolEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public Structured Encode(ItestDmnBoolDiff input)
    => new(input.Value);

  internal static testDmnBoolDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public Structured Encode(ItestDmnBoolSame input)
    => new(input.Value);

  internal static testDmnBoolSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => new((decimal?)input.Value);

  internal static testDmnEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public Structured Encode(ItestDmnEnumSame input)
    => new((decimal?)input.Value);

  internal static testDmnEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public Structured Encode(ItestDmnNmbr input)
    => new(input.Value);

  internal static testDmnNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public Structured Encode(ItestDmnNmbrDiff input)
    => new(input.Value);

  internal static testDmnNmbrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public Structured Encode(ItestDmnNmbrSame input)
    => new(input.Value);

  internal static testDmnNmbrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public Structured Encode(ItestDmnStr input)
    => new(input.Value);

  internal static testDmnStrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public Structured Encode(ItestDmnStrDiff input)
    => new(input.Value);

  internal static testDmnStrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public Structured Encode(ItestDmnStrSame input)
    => new(input.Value);

  internal static testDmnStrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => new(input.ToString(), "_EnumAlias");

  internal static testEnumAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public Structured Encode(testEnumDiff input)
    => new(input.ToString(), "_EnumDiff");

  internal static testEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public Structured Encode(testEnumSame input)
    => new(input.ToString(), "_EnumSame");

  internal static testEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public Structured Encode(testEnumSamePrnt input)
    => new(input.ToString(), "_EnumSamePrnt");

  internal static testEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public Structured Encode(testPrntEnumSamePrnt input)
    => new(input.ToString(), "_PrntEnumSamePrnt");

  internal static testPrntEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public Structured Encode(testEnumValueAlias input)
    => new(input.ToString(), "_EnumValueAlias");

  internal static testEnumValueAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public Structured Encode(ItestObjDualObject input)
    => Structured.Empty();

  internal static testObjDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("field", input.Field);

  internal static testObjFieldEnumAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldEnumAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public Structured Encode(ItestObjFieldEnumValueDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldEnumValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public Structured Encode(ItestObjFieldEnumValueOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldEnumValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public Structured Encode(ItestObjFieldTypeAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldTypeAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

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
      .AddEncoder<ItestObjOutpObject>(testObjOutpEncoder.Factory)
      .AddEncoder<ItestObjAliasDualObject>(testObjAliasDualEncoder.Factory)
      .AddEncoder<ItestObjAliasOutpObject>(testObjAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjAltDualObject>(testObjAltDualEncoder.Factory)
      .AddEncoder<ItestObjAltDualTypeObject>(testObjAltDualTypeEncoder.Factory)
      .AddEncoder<ItestObjAltOutpObject>(testObjAltOutpEncoder.Factory)
      .AddEncoder<ItestObjAltOutpTypeObject>(testObjAltOutpTypeEncoder.Factory)
      .AddEncoder<ItestObjAltEnumDualObject>(testObjAltEnumDualEncoder.Factory)
      .AddEncoder<ItestObjAltEnumOutpObject>(testObjAltEnumOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldDualObject>(testObjFieldDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldDualObject>(testFldObjFieldDualEncoder.Factory)
      .AddEncoder<ItestObjFieldOutpObject>(testObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldOutpObject>(testFldObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasOutpObject>(testObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasOutpObject>(testFldObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasOutpObject>(testObjFieldEnumAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueOutpObject>(testObjFieldEnumValueOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasOutpObject>(testObjFieldTypeAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjPrntDualObject>(testObjPrntDualEncoder.Factory)
      .AddEncoder<ItestRefObjPrntDualObject>(testRefObjPrntDualEncoder.Factory)
      .AddEncoder<ItestObjPrntOutpObject>(testObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestRefObjPrntOutpObject>(testRefObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestOutpFieldParamObject>(testOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestUnionAlias>(testUnionAliasEncoder.Factory)
      .AddEncoder<ItestUnionDiff>(testUnionDiffEncoder.Factory)
      .AddEncoder<ItestUnionSame>(testUnionSameEncoder.Factory)
      .AddEncoder<ItestUnionSamePrnt>(testUnionSamePrntEncoder.Factory)
      .AddEncoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntEncoder.Factory);
}
