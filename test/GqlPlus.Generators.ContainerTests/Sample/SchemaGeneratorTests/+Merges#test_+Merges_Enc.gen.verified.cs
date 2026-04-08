//HintName: test_+Merges_Enc.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public class testCtgr
  : GqlpEncoderBase
  , ItestCtgr
{
  public ItestCtgrObject? As_Ctgr { get; set; }
}

public class testCtgrObject
  : GqlpEncoderBase
  , ItestCtgrObject
{

  public testCtgrObject
    ()
  {
  }
}

public class testCtgrAlias
  : GqlpEncoderBase
  , ItestCtgrAlias
{
  public ItestCtgrAliasObject? As_CtgrAlias { get; set; }
}

public class testCtgrAliasObject
  : GqlpEncoderBase
  , ItestCtgrAliasObject
{

  public testCtgrAliasObject
    ()
  {
  }
}

public class testCtgrDescr
  : GqlpEncoderBase
  , ItestCtgrDescr
{
  public ItestCtgrDescrObject? As_CtgrDescr { get; set; }
}

public class testCtgrDescrObject
  : GqlpEncoderBase
  , ItestCtgrDescrObject
{

  public testCtgrDescrObject
    ()
  {
  }
}

public class testCtgrMod
  : GqlpEncoderBase
  , ItestCtgrMod
{
  public ItestCtgrModObject? As_CtgrMod { get; set; }
}

public class testCtgrModObject
  : GqlpEncoderBase
  , ItestCtgrModObject
{

  public testCtgrModObject
    ()
  {
  }
}

public class testInDrctParam
  : GqlpEncoderBase
  , ItestInDrctParam
{
  public ItestInDrctParamObject? As_InDrctParam { get; set; }
}

public class testInDrctParamObject
  : GqlpEncoderBase
  , ItestInDrctParamObject
{

  public testInDrctParamObject
    ()
  {
  }
}

public class testDmnAlias
  : GqlpDomainNumber
  , ItestDmnAlias
{
}

public class testDmnBool
  : GqlpDomainBoolean
  , ItestDmnBool
{
}

public class testDmnBoolDiff
  : GqlpDomainBoolean
  , ItestDmnBoolDiff
{
}

public class testDmnBoolSame
  : GqlpDomainBoolean
  , ItestDmnBoolSame
{
}

public class testDmnEnumDiff
  : GqlpDomainEnum
  , ItestDmnEnumDiff
{
}

public class testDmnEnumSame
  : GqlpDomainEnum
  , ItestDmnEnumSame
{
}

public class testDmnNmbr
  : GqlpDomainNumber
  , ItestDmnNmbr
{
}

public class testDmnNmbrDiff
  : GqlpDomainNumber
  , ItestDmnNmbrDiff
{
}

public class testDmnNmbrSame
  : GqlpDomainNumber
  , ItestDmnNmbrSame
{
}

public class testDmnStr
  : GqlpDomainString
  , ItestDmnStr
{
}

public class testDmnStrDiff
  : GqlpDomainString
  , ItestDmnStrDiff
{
}

public class testDmnStrSame
  : GqlpDomainString
  , ItestDmnStrSame
{
}

public enum testEnumAlias
{
  enumAlias,
}

public enum testEnumDiff
{
  one,
  two,
}

public enum testEnumSame
{
  enumSame,
}

public enum testEnumSamePrnt
{
  prnt_enumSamePrnt = testPrntEnumSamePrnt.prnt_enumSamePrnt,
  enumSamePrnt,
}

public enum testPrntEnumSamePrnt
{
  prnt_enumSamePrnt,
}

public enum testEnumValueAlias
{
  enumValueAlias,
  val1 = enumValueAlias,
  val2 = enumValueAlias,
}

public class testObjDual
  : GqlpEncoderBase
  , ItestObjDual
{
  public ItestObjDualObject? As_ObjDual { get; set; }
}

public class testObjDualObject
  : GqlpEncoderBase
  , ItestObjDualObject
{

  public testObjDualObject
    ()
  {
  }
}

public class testObjInp
  : GqlpEncoderBase
  , ItestObjInp
{
  public ItestObjInpObject? As_ObjInp { get; set; }
}

public class testObjInpObject
  : GqlpEncoderBase
  , ItestObjInpObject
{

  public testObjInpObject
    ()
  {
  }
}

public class testObjOutp
  : GqlpEncoderBase
  , ItestObjOutp
{
  public ItestObjOutpObject? As_ObjOutp { get; set; }
}

public class testObjOutpObject
  : GqlpEncoderBase
  , ItestObjOutpObject
{

  public testObjOutpObject
    ()
  {
  }
}

public class testObjAliasDual
  : GqlpEncoderBase
  , ItestObjAliasDual
{
  public ItestObjAliasDualObject? As_ObjAliasDual { get; set; }
}

public class testObjAliasDualObject
  : GqlpEncoderBase
  , ItestObjAliasDualObject
{

  public testObjAliasDualObject
    ()
  {
  }
}

public class testObjAliasInp
  : GqlpEncoderBase
  , ItestObjAliasInp
{
  public ItestObjAliasInpObject? As_ObjAliasInp { get; set; }
}

public class testObjAliasInpObject
  : GqlpEncoderBase
  , ItestObjAliasInpObject
{

  public testObjAliasInpObject
    ()
  {
  }
}

public class testObjAliasOutp
  : GqlpEncoderBase
  , ItestObjAliasOutp
{
  public ItestObjAliasOutpObject? As_ObjAliasOutp { get; set; }
}

public class testObjAliasOutpObject
  : GqlpEncoderBase
  , ItestObjAliasOutpObject
{

  public testObjAliasOutpObject
    ()
  {
  }
}

public class testObjAltDual
  : GqlpEncoderBase
  , ItestObjAltDual
{
  public ItestObjAltDualType? AsObjAltDualType { get; set; }
  public ItestObjAltDualObject? As_ObjAltDual { get; set; }
}

public class testObjAltDualObject
  : GqlpEncoderBase
  , ItestObjAltDualObject
{

  public testObjAltDualObject
    ()
  {
  }
}

public class testObjAltDualType
  : GqlpEncoderBase
  , ItestObjAltDualType
{
  public ItestObjAltDualTypeObject? As_ObjAltDualType { get; set; }
}

public class testObjAltDualTypeObject
  : GqlpEncoderBase
  , ItestObjAltDualTypeObject
{

  public testObjAltDualTypeObject
    ()
  {
  }
}

public class testObjAltInp
  : GqlpEncoderBase
  , ItestObjAltInp
{
  public ItestObjAltInpType? AsObjAltInpType { get; set; }
  public ItestObjAltInpObject? As_ObjAltInp { get; set; }
}

public class testObjAltInpObject
  : GqlpEncoderBase
  , ItestObjAltInpObject
{

  public testObjAltInpObject
    ()
  {
  }
}

public class testObjAltInpType
  : GqlpEncoderBase
  , ItestObjAltInpType
{
  public ItestObjAltInpTypeObject? As_ObjAltInpType { get; set; }
}

public class testObjAltInpTypeObject
  : GqlpEncoderBase
  , ItestObjAltInpTypeObject
{

  public testObjAltInpTypeObject
    ()
  {
  }
}

public class testObjAltOutp
  : GqlpEncoderBase
  , ItestObjAltOutp
{
  public ItestObjAltOutpType? AsObjAltOutpType { get; set; }
  public ItestObjAltOutpObject? As_ObjAltOutp { get; set; }
}

public class testObjAltOutpObject
  : GqlpEncoderBase
  , ItestObjAltOutpObject
{

  public testObjAltOutpObject
    ()
  {
  }
}

public class testObjAltOutpType
  : GqlpEncoderBase
  , ItestObjAltOutpType
{
  public ItestObjAltOutpTypeObject? As_ObjAltOutpType { get; set; }
}

public class testObjAltOutpTypeObject
  : GqlpEncoderBase
  , ItestObjAltOutpTypeObject
{

  public testObjAltOutpTypeObject
    ()
  {
  }
}

public class testObjAltEnumDual
  : GqlpEncoderBase
  , ItestObjAltEnumDual
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumDualObject? As_ObjAltEnumDual { get; set; }
}

public class testObjAltEnumDualObject
  : GqlpEncoderBase
  , ItestObjAltEnumDualObject
{

  public testObjAltEnumDualObject
    ()
  {
  }
}

public class testObjAltEnumInp
  : GqlpEncoderBase
  , ItestObjAltEnumInp
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumInpObject? As_ObjAltEnumInp { get; set; }
}

public class testObjAltEnumInpObject
  : GqlpEncoderBase
  , ItestObjAltEnumInpObject
{

  public testObjAltEnumInpObject
    ()
  {
  }
}

public class testObjAltEnumOutp
  : GqlpEncoderBase
  , ItestObjAltEnumOutp
{
  public bool? AsBooleantrue { get; set; }
  public bool? AsBooleanfalse { get; set; }
  public ItestObjAltEnumOutpObject? As_ObjAltEnumOutp { get; set; }
}

public class testObjAltEnumOutpObject
  : GqlpEncoderBase
  , ItestObjAltEnumOutpObject
{

  public testObjAltEnumOutpObject
    ()
  {
  }
}

public class testObjCnstDual<TType>
  : GqlpEncoderBase
  , ItestObjCnstDual<TType>
{
  public ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; set; }
}

public class testObjCnstDualObject<TType>
  : GqlpEncoderBase
  , ItestObjCnstDualObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstDualObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}

public class testObjCnstInp<TType>
  : GqlpEncoderBase
  , ItestObjCnstInp<TType>
{
  public ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; set; }
}

public class testObjCnstInpObject<TType>
  : GqlpEncoderBase
  , ItestObjCnstInpObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstInpObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}

public class testObjCnstOutp<TType>
  : GqlpEncoderBase
  , ItestObjCnstOutp<TType>
{
  public ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; set; }
}

public class testObjCnstOutpObject<TType>
  : GqlpEncoderBase
  , ItestObjCnstOutpObject<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }

  public testObjCnstOutpObject
    ( TType field
    , TType str
    )
  {
    Field = field;
    Str = str;
  }
}

public class testObjFieldDual
  : GqlpEncoderBase
  , ItestObjFieldDual
{
  public ItestObjFieldDualObject? As_ObjFieldDual { get; set; }
}

public class testObjFieldDualObject
  : GqlpEncoderBase
  , ItestObjFieldDualObject
{
  public ItestFldObjFieldDual Field { get; set; }

  public testObjFieldDualObject
    ( ItestFldObjFieldDual field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldDual
  : GqlpEncoderBase
  , ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject? As_FldObjFieldDual { get; set; }
}

public class testFldObjFieldDualObject
  : GqlpEncoderBase
  , ItestFldObjFieldDualObject
{

  public testFldObjFieldDualObject
    ()
  {
  }
}

public class testObjFieldInp
  : GqlpEncoderBase
  , ItestObjFieldInp
{
  public ItestObjFieldInpObject? As_ObjFieldInp { get; set; }
}

public class testObjFieldInpObject
  : GqlpEncoderBase
  , ItestObjFieldInpObject
{
  public ItestFldObjFieldInp Field { get; set; }

  public testObjFieldInpObject
    ( ItestFldObjFieldInp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldInp
  : GqlpEncoderBase
  , ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject? As_FldObjFieldInp { get; set; }
}

public class testFldObjFieldInpObject
  : GqlpEncoderBase
  , ItestFldObjFieldInpObject
{

  public testFldObjFieldInpObject
    ()
  {
  }
}

public class testObjFieldOutp
  : GqlpEncoderBase
  , ItestObjFieldOutp
{
  public ItestObjFieldOutpObject? As_ObjFieldOutp { get; set; }
}

public class testObjFieldOutpObject
  : GqlpEncoderBase
  , ItestObjFieldOutpObject
{
  public ItestFldObjFieldOutp Field { get; set; }

  public testObjFieldOutpObject
    ( ItestFldObjFieldOutp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldOutp
  : GqlpEncoderBase
  , ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; set; }
}

public class testFldObjFieldOutpObject
  : GqlpEncoderBase
  , ItestFldObjFieldOutpObject
{

  public testFldObjFieldOutpObject
    ()
  {
  }
}

public class testObjFieldAliasDual
  : GqlpEncoderBase
  , ItestObjFieldAliasDual
{
  public ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; set; }
}

public class testObjFieldAliasDualObject
  : GqlpEncoderBase
  , ItestObjFieldAliasDualObject
{
  public ItestFldObjFieldAliasDual Field { get; set; }

  public testObjFieldAliasDualObject
    ( ItestFldObjFieldAliasDual field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasDual
  : GqlpEncoderBase
  , ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; set; }
}

public class testFldObjFieldAliasDualObject
  : GqlpEncoderBase
  , ItestFldObjFieldAliasDualObject
{

  public testFldObjFieldAliasDualObject
    ()
  {
  }
}

public class testObjFieldAliasInp
  : GqlpEncoderBase
  , ItestObjFieldAliasInp
{
  public ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; set; }
}

public class testObjFieldAliasInpObject
  : GqlpEncoderBase
  , ItestObjFieldAliasInpObject
{
  public ItestFldObjFieldAliasInp Field { get; set; }

  public testObjFieldAliasInpObject
    ( ItestFldObjFieldAliasInp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasInp
  : GqlpEncoderBase
  , ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; set; }
}

public class testFldObjFieldAliasInpObject
  : GqlpEncoderBase
  , ItestFldObjFieldAliasInpObject
{

  public testFldObjFieldAliasInpObject
    ()
  {
  }
}

public class testObjFieldAliasOutp
  : GqlpEncoderBase
  , ItestObjFieldAliasOutp
{
  public ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; set; }
}

public class testObjFieldAliasOutpObject
  : GqlpEncoderBase
  , ItestObjFieldAliasOutpObject
{
  public ItestFldObjFieldAliasOutp Field { get; set; }

  public testObjFieldAliasOutpObject
    ( ItestFldObjFieldAliasOutp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasOutp
  : GqlpEncoderBase
  , ItestFldObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; set; }
}

public class testFldObjFieldAliasOutpObject
  : GqlpEncoderBase
  , ItestFldObjFieldAliasOutpObject
{

  public testFldObjFieldAliasOutpObject
    ()
  {
  }
}

public class testObjFieldEnumAliasDual
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasDual
{
  public ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; set; }
}

public class testObjFieldEnumAliasDualObject
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasDualObject
{
  public bool Field { get; set; }

  public testObjFieldEnumAliasDualObject
    ( bool field
    )
  {
    Field = field;
  }
}

public class testObjFieldEnumAliasInp
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasInp
{
  public ItestObjFieldEnumAliasInpObject? As_ObjFieldEnumAliasInp { get; set; }
}

public class testObjFieldEnumAliasInpObject
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasInpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumAliasInpObject
    ( bool field
    )
  {
    Field = field;
  }
}

public class testObjFieldEnumAliasOutp
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasOutp
{
  public ItestObjFieldEnumAliasOutpObject? As_ObjFieldEnumAliasOutp { get; set; }
}

public class testObjFieldEnumAliasOutpObject
  : GqlpEncoderBase
  , ItestObjFieldEnumAliasOutpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumAliasOutpObject
    ( bool field
    )
  {
    Field = field;
  }
}

public class testObjFieldEnumValueDual
  : GqlpEncoderBase
  , ItestObjFieldEnumValueDual
{
  public ItestObjFieldEnumValueDualObject? As_ObjFieldEnumValueDual { get; set; }
}

public class testObjFieldEnumValueDualObject
  : GqlpEncoderBase
  , ItestObjFieldEnumValueDualObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueDualObject
    ( bool field
    )
  {
    Field = field;
  }
}

public class testObjFieldEnumValueInp
  : GqlpEncoderBase
  , ItestObjFieldEnumValueInp
{
  public ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; set; }
}

public class testObjFieldEnumValueInpObject
  : GqlpEncoderBase
  , ItestObjFieldEnumValueInpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueInpObject
    ( bool field
    )
  {
    Field = field;
  }
}

public class testObjFieldEnumValueOutp
  : GqlpEncoderBase
  , ItestObjFieldEnumValueOutp
{
  public ItestObjFieldEnumValueOutpObject? As_ObjFieldEnumValueOutp { get; set; }
}

public class testObjFieldEnumValueOutpObject
  : GqlpEncoderBase
  , ItestObjFieldEnumValueOutpObject
{
  public bool Field { get; set; }

  public testObjFieldEnumValueOutpObject
    ( bool field
    )
  {
    Field = field;
  }
}

public class testObjFieldTypeAliasDual
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasDual
{
  public ItestObjFieldTypeAliasDualObject? As_ObjFieldTypeAliasDual { get; set; }
}

public class testObjFieldTypeAliasDualObject
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasDualObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasDualObject
    ( string field
    )
  {
    Field = field;
  }
}

public class testObjFieldTypeAliasInp
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasInp
{
  public ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; set; }
}

public class testObjFieldTypeAliasInpObject
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasInpObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasInpObject
    ( string field
    )
  {
    Field = field;
  }
}

public class testObjFieldTypeAliasOutp
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasOutp
{
  public ItestObjFieldTypeAliasOutpObject? As_ObjFieldTypeAliasOutp { get; set; }
}

public class testObjFieldTypeAliasOutpObject
  : GqlpEncoderBase
  , ItestObjFieldTypeAliasOutpObject
{
  public string Field { get; set; }

  public testObjFieldTypeAliasOutpObject
    ( string field
    )
  {
    Field = field;
  }
}

public class testObjParamDual<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamDual<TTest,TType>
{
  public ItestObjParamDualObject<TTest,TType>? As_ObjParamDual { get; set; }
}

public class testObjParamDualObject<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamDualObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamDualObject
    ( TTest test
    , TType type
    )
  {
    Test = test;
    Type = type;
  }
}

public class testObjParamInp<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamInp<TTest,TType>
{
  public ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; set; }
}

public class testObjParamInpObject<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamInpObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamInpObject
    ( TTest test
    , TType type
    )
  {
    Test = test;
    Type = type;
  }
}

public class testObjParamOutp<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamOutp<TTest,TType>
{
  public ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; set; }
}

public class testObjParamOutpObject<TTest,TType>
  : GqlpEncoderBase
  , ItestObjParamOutpObject<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }

  public testObjParamOutpObject
    ( TTest test
    , TType type
    )
  {
    Test = test;
    Type = type;
  }
}

public class testObjParamDupDual<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupDual<TTest>
{
  public ItestObjParamDupDualObject<TTest>? As_ObjParamDupDual { get; set; }
}

public class testObjParamDupDualObject<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupDualObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupDualObject
    ( TTest test
    , TTest type
    )
  {
    Test = test;
    Type = type;
  }
}

public class testObjParamDupInp<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupInp<TTest>
{
  public ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; set; }
}

public class testObjParamDupInpObject<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupInpObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupInpObject
    ( TTest test
    , TTest type
    )
  {
    Test = test;
    Type = type;
  }
}

public class testObjParamDupOutp<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupOutp<TTest>
{
  public ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; set; }
}

public class testObjParamDupOutpObject<TTest>
  : GqlpEncoderBase
  , ItestObjParamDupOutpObject<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }

  public testObjParamDupOutpObject
    ( TTest test
    , TTest type
    )
  {
    Test = test;
    Type = type;
  }
}

public class testObjPrntDual
  : testRefObjPrntDual
  , ItestObjPrntDual
{
  public ItestObjPrntDualObject? As_ObjPrntDual { get; set; }
}

public class testObjPrntDualObject
  : testRefObjPrntDualObject
  , ItestObjPrntDualObject
{

  public testObjPrntDualObject
    ()
  {
  }
}

public class testRefObjPrntDual
  : GqlpEncoderBase
  , ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject? As_RefObjPrntDual { get; set; }
}

public class testRefObjPrntDualObject
  : GqlpEncoderBase
  , ItestRefObjPrntDualObject
{

  public testRefObjPrntDualObject
    ()
  {
  }
}

public class testObjPrntInp
  : testRefObjPrntInp
  , ItestObjPrntInp
{
  public ItestObjPrntInpObject? As_ObjPrntInp { get; set; }
}

public class testObjPrntInpObject
  : testRefObjPrntInpObject
  , ItestObjPrntInpObject
{

  public testObjPrntInpObject
    ()
  {
  }
}

public class testRefObjPrntInp
  : GqlpEncoderBase
  , ItestRefObjPrntInp
{
  public ItestRefObjPrntInpObject? As_RefObjPrntInp { get; set; }
}

public class testRefObjPrntInpObject
  : GqlpEncoderBase
  , ItestRefObjPrntInpObject
{

  public testRefObjPrntInpObject
    ()
  {
  }
}

public class testObjPrntOutp
  : testRefObjPrntOutp
  , ItestObjPrntOutp
{
  public ItestObjPrntOutpObject? As_ObjPrntOutp { get; set; }
}

public class testObjPrntOutpObject
  : testRefObjPrntOutpObject
  , ItestObjPrntOutpObject
{

  public testObjPrntOutpObject
    ()
  {
  }
}

public class testRefObjPrntOutp
  : GqlpEncoderBase
  , ItestRefObjPrntOutp
{
  public ItestRefObjPrntOutpObject? As_RefObjPrntOutp { get; set; }
}

public class testRefObjPrntOutpObject
  : GqlpEncoderBase
  , ItestRefObjPrntOutpObject
{

  public testRefObjPrntOutpObject
    ()
  {
  }
}

public class testOutpFieldParam
  : GqlpEncoderBase
  , ItestOutpFieldParam
{
  public ItestOutpFieldParamObject? As_OutpFieldParam { get; set; }
}

public class testOutpFieldParamObject
  : GqlpEncoderBase
  , ItestOutpFieldParamObject
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;

  public testOutpFieldParamObject
    ()
  {
  }
}

public class testOutpFieldParam1
  : GqlpEncoderBase
  , ItestOutpFieldParam1
{
  public ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; set; }
}

public class testOutpFieldParam1Object
  : GqlpEncoderBase
  , ItestOutpFieldParam1Object
{

  public testOutpFieldParam1Object
    ()
  {
  }
}

public class testOutpFieldParam2
  : GqlpEncoderBase
  , ItestOutpFieldParam2
{
  public ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; set; }
}

public class testOutpFieldParam2Object
  : GqlpEncoderBase
  , ItestOutpFieldParam2Object
{

  public testOutpFieldParam2Object
    ()
  {
  }
}

public class testFldOutpFieldParam
  : GqlpEncoderBase
  , ItestFldOutpFieldParam
{
  public ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; set; }
}

public class testFldOutpFieldParamObject
  : GqlpEncoderBase
  , ItestFldOutpFieldParamObject
{

  public testFldOutpFieldParamObject
    ()
  {
  }
}

public class testUnionAlias
  : GqlpEncoderBase
  , ItestUnionAlias
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

public class testUnionDiff
  : GqlpEncoderBase
  , ItestUnionDiff
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

public class testUnionSame
  : GqlpEncoderBase
  , ItestUnionSame
{
  public Boolean AsBoolean { get; set; }
}

public class testUnionSamePrnt
  : testPrntUnionSamePrnt
  , ItestUnionSamePrnt
{
  public Boolean AsBoolean { get; set; }
}

public class testPrntUnionSamePrnt
  : GqlpEncoderBase
  , ItestPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
