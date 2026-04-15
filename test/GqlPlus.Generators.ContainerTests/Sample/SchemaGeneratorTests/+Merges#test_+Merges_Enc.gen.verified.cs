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
}

internal class testCtgrAliasEncoder : IEncoder<ItestCtgrAliasObject>
{
  public Structured Encode(ItestCtgrAliasObject input)
    => Structured.Empty();
}

internal class testCtgrDescrEncoder : IEncoder<ItestCtgrDescrObject>
{
  public Structured Encode(ItestCtgrDescrObject input)
    => Structured.Empty();
}

internal class testCtgrModEncoder : IEncoder<ItestCtgrModObject>
{
  public Structured Encode(ItestCtgrModObject input)
    => Structured.Empty();
}

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => new(input.Value);
}

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => new(input.Value);
}

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public Structured Encode(ItestDmnBoolDiff input)
    => new(input.Value);
}

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public Structured Encode(ItestDmnBoolSame input)
    => new(input.Value);
}

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => new((decimal?)input.Value);
}

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public Structured Encode(ItestDmnEnumSame input)
    => new((decimal?)input.Value);
}

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public Structured Encode(ItestDmnNmbr input)
    => new(input.Value);
}

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public Structured Encode(ItestDmnNmbrDiff input)
    => new(input.Value);
}

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public Structured Encode(ItestDmnNmbrSame input)
    => new(input.Value);
}

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public Structured Encode(ItestDmnStr input)
    => new(input.Value);
}

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public Structured Encode(ItestDmnStrDiff input)
    => new(input.Value);
}

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public Structured Encode(ItestDmnStrSame input)
    => new(input.Value);
}

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => new(input.ToString(), "_EnumAlias");
}

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public Structured Encode(testEnumDiff input)
    => new(input.ToString(), "_EnumDiff");
}

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public Structured Encode(testEnumSame input)
    => new(input.ToString(), "_EnumSame");
}

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public Structured Encode(testEnumSamePrnt input)
    => new(input.ToString(), "_EnumSamePrnt");
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public Structured Encode(testPrntEnumSamePrnt input)
    => new(input.ToString(), "_PrntEnumSamePrnt");
}

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public Structured Encode(testEnumValueAlias input)
    => new(input.ToString(), "_EnumValueAlias");
}

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public Structured Encode(ItestObjDualObject input)
    => Structured.Empty();
}

internal class testObjOutpEncoder : IEncoder<ItestObjOutpObject>
{
  public Structured Encode(ItestObjOutpObject input)
    => Structured.Empty();
}

internal class testObjAliasDualEncoder : IEncoder<ItestObjAliasDualObject>
{
  public Structured Encode(ItestObjAliasDualObject input)
    => Structured.Empty();
}

internal class testObjAliasOutpEncoder : IEncoder<ItestObjAliasOutpObject>
{
  public Structured Encode(ItestObjAliasOutpObject input)
    => Structured.Empty();
}

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public Structured Encode(ItestObjAltDualObject input)
    => Structured.Empty();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public Structured Encode(ItestObjAltDualTypeObject input)
    => Structured.Empty();
}

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public Structured Encode(ItestObjAltOutpObject input)
    => Structured.Empty();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public Structured Encode(ItestObjAltOutpTypeObject input)
    => Structured.Empty();
}

internal class testObjAltEnumDualEncoder : IEncoder<ItestObjAltEnumDualObject>
{
  public Structured Encode(ItestObjAltEnumDualObject input)
    => Structured.Empty();
}

internal class testObjAltEnumOutpEncoder : IEncoder<ItestObjAltEnumOutpObject>
{
  public Structured Encode(ItestObjAltEnumOutpObject input)
    => Structured.Empty();
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
}

internal class testFldObjFieldDualEncoder : IEncoder<ItestFldObjFieldDualObject>
{
  public Structured Encode(ItestFldObjFieldDualObject input)
    => Structured.Empty();
}

internal class testObjFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldOutp> _itestFldObjFieldOutp = encoders.EncoderFor<ItestFldObjFieldOutp>();
  public Structured Encode(ItestObjFieldOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldOutp);
}

internal class testFldObjFieldOutpEncoder : IEncoder<ItestFldObjFieldOutpObject>
{
  public Structured Encode(ItestFldObjFieldOutpObject input)
    => Structured.Empty();
}

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public Structured Encode(ItestObjFieldAliasDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public Structured Encode(ItestFldObjFieldAliasDualObject input)
    => Structured.Empty();
}

internal class testObjFieldAliasOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasOutp> _itestFldObjFieldAliasOutp = encoders.EncoderFor<ItestFldObjFieldAliasOutp>();
  public Structured Encode(ItestObjFieldAliasOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasOutp);
}

internal class testFldObjFieldAliasOutpEncoder : IEncoder<ItestFldObjFieldAliasOutpObject>
{
  public Structured Encode(ItestFldObjFieldAliasOutpObject input)
    => Structured.Empty();
}

internal class testObjFieldEnumAliasDualEncoder : IEncoder<ItestObjFieldEnumAliasDualObject>
{
  public Structured Encode(ItestObjFieldEnumAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public Structured Encode(ItestObjFieldEnumValueDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public Structured Encode(ItestObjFieldEnumValueOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public Structured Encode(ItestObjFieldTypeAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
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
}

internal class testRefObjPrntDualEncoder : IEncoder<ItestRefObjPrntDualObject>
{
  public Structured Encode(ItestRefObjPrntDualObject input)
    => Structured.Empty();
}

internal class testObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefObjPrntOutpObject> _itestRefObjPrntOutp = encoders.EncoderFor<ItestRefObjPrntOutpObject>();
  public Structured Encode(ItestObjPrntOutpObject input)
    => _itestRefObjPrntOutp.Encode(input);
}

internal class testRefObjPrntOutpEncoder : IEncoder<ItestRefObjPrntOutpObject>
{
  public Structured Encode(ItestRefObjPrntOutpObject input)
    => Structured.Empty();
}

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly IEncoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public Structured Encode(ItestOutpFieldParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpFieldParam);
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public Structured Encode(ItestFldOutpFieldParamObject input)
    => Structured.Empty();
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
}

internal class testUnionSameEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSame>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSame input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();
}

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSamePrnt>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();
}

internal static class test__MergesEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__MergesEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrObject>(_ => new testCtgrEncoder())
      .AddEncoder<ItestCtgrAliasObject>(_ => new testCtgrAliasEncoder())
      .AddEncoder<ItestCtgrDescrObject>(_ => new testCtgrDescrEncoder())
      .AddEncoder<ItestCtgrModObject>(_ => new testCtgrModEncoder())
      .AddEncoder<ItestDmnAlias>(_ => new testDmnAliasEncoder())
      .AddEncoder<ItestDmnBool>(_ => new testDmnBoolEncoder())
      .AddEncoder<ItestDmnBoolDiff>(_ => new testDmnBoolDiffEncoder())
      .AddEncoder<ItestDmnBoolSame>(_ => new testDmnBoolSameEncoder())
      .AddEncoder<ItestDmnEnumDiff>(_ => new testDmnEnumDiffEncoder())
      .AddEncoder<ItestDmnEnumSame>(_ => new testDmnEnumSameEncoder())
      .AddEncoder<ItestDmnNmbr>(_ => new testDmnNmbrEncoder())
      .AddEncoder<ItestDmnNmbrDiff>(_ => new testDmnNmbrDiffEncoder())
      .AddEncoder<ItestDmnNmbrSame>(_ => new testDmnNmbrSameEncoder())
      .AddEncoder<ItestDmnStr>(_ => new testDmnStrEncoder())
      .AddEncoder<ItestDmnStrDiff>(_ => new testDmnStrDiffEncoder())
      .AddEncoder<ItestDmnStrSame>(_ => new testDmnStrSameEncoder())
      .AddEncoder<testEnumAlias>(_ => new testEnumAliasEncoder())
      .AddEncoder<testEnumDiff>(_ => new testEnumDiffEncoder())
      .AddEncoder<testEnumSame>(_ => new testEnumSameEncoder())
      .AddEncoder<testEnumSamePrnt>(_ => new testEnumSamePrntEncoder())
      .AddEncoder<testPrntEnumSamePrnt>(_ => new testPrntEnumSamePrntEncoder())
      .AddEncoder<testEnumValueAlias>(_ => new testEnumValueAliasEncoder())
      .AddEncoder<ItestObjDualObject>(_ => new testObjDualEncoder())
      .AddEncoder<ItestObjOutpObject>(_ => new testObjOutpEncoder())
      .AddEncoder<ItestObjAliasDualObject>(_ => new testObjAliasDualEncoder())
      .AddEncoder<ItestObjAliasOutpObject>(_ => new testObjAliasOutpEncoder())
      .AddEncoder<ItestObjAltDualObject>(_ => new testObjAltDualEncoder())
      .AddEncoder<ItestObjAltDualTypeObject>(_ => new testObjAltDualTypeEncoder())
      .AddEncoder<ItestObjAltOutpObject>(_ => new testObjAltOutpEncoder())
      .AddEncoder<ItestObjAltOutpTypeObject>(_ => new testObjAltOutpTypeEncoder())
      .AddEncoder<ItestObjAltEnumDualObject>(_ => new testObjAltEnumDualEncoder())
      .AddEncoder<ItestObjAltEnumOutpObject>(_ => new testObjAltEnumOutpEncoder())
      .AddEncoder<ItestObjFieldDualObject>(r => new testObjFieldDualEncoder(r))
      .AddEncoder<ItestFldObjFieldDualObject>(_ => new testFldObjFieldDualEncoder())
      .AddEncoder<ItestObjFieldOutpObject>(r => new testObjFieldOutpEncoder(r))
      .AddEncoder<ItestFldObjFieldOutpObject>(_ => new testFldObjFieldOutpEncoder())
      .AddEncoder<ItestObjFieldAliasDualObject>(r => new testObjFieldAliasDualEncoder(r))
      .AddEncoder<ItestFldObjFieldAliasDualObject>(_ => new testFldObjFieldAliasDualEncoder())
      .AddEncoder<ItestObjFieldAliasOutpObject>(r => new testObjFieldAliasOutpEncoder(r))
      .AddEncoder<ItestFldObjFieldAliasOutpObject>(_ => new testFldObjFieldAliasOutpEncoder())
      .AddEncoder<ItestObjFieldEnumAliasDualObject>(_ => new testObjFieldEnumAliasDualEncoder())
      .AddEncoder<ItestObjFieldEnumAliasOutpObject>(_ => new testObjFieldEnumAliasOutpEncoder())
      .AddEncoder<ItestObjFieldEnumValueDualObject>(_ => new testObjFieldEnumValueDualEncoder())
      .AddEncoder<ItestObjFieldEnumValueOutpObject>(_ => new testObjFieldEnumValueOutpEncoder())
      .AddEncoder<ItestObjFieldTypeAliasDualObject>(_ => new testObjFieldTypeAliasDualEncoder())
      .AddEncoder<ItestObjFieldTypeAliasOutpObject>(_ => new testObjFieldTypeAliasOutpEncoder())
      .AddEncoder<ItestObjPrntDualObject>(r => new testObjPrntDualEncoder(r))
      .AddEncoder<ItestRefObjPrntDualObject>(_ => new testRefObjPrntDualEncoder())
      .AddEncoder<ItestObjPrntOutpObject>(r => new testObjPrntOutpEncoder(r))
      .AddEncoder<ItestRefObjPrntOutpObject>(_ => new testRefObjPrntOutpEncoder())
      .AddEncoder<ItestOutpFieldParamObject>(r => new testOutpFieldParamEncoder(r))
      .AddEncoder<ItestFldOutpFieldParamObject>(_ => new testFldOutpFieldParamEncoder())
      .AddEncoder<ItestUnionAlias>(r => new testUnionAliasEncoder(r))
      .AddEncoder<ItestUnionDiff>(r => new testUnionDiffEncoder(r))
      .AddEncoder<ItestUnionSame>(r => new testUnionSameEncoder(r))
      .AddEncoder<ItestUnionSamePrnt>(r => new testUnionSamePrntEncoder(r))
      .AddEncoder<ItestPrntUnionSamePrnt>(r => new testPrntUnionSamePrntEncoder(r));
}
