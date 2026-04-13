//HintName: test_+Simple_Model.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class testDmnBoolDescr
  : GqlpDomainBoolean
  , ItestDmnBoolDescr
{
}

public class testDmnBoolPrnt
  : testPrntDmnBoolPrnt
  , ItestDmnBoolPrnt
{
}

public class testPrntDmnBoolPrnt
  : GqlpDomainBoolean
  , ItestPrntDmnBoolPrnt
{
}

public class testDmnBoolPrntDescr
  : testPrntDmnBoolPrntDescr
  , ItestDmnBoolPrntDescr
{
}

public class testPrntDmnBoolPrntDescr
  : GqlpDomainBoolean
  , ItestPrntDmnBoolPrntDescr
{
}

public class testDmnEnumAll
  : GqlpDomainEnum
  , ItestDmnEnumAll
{
}

public class testDmnEnumAllDescr
  : GqlpDomainEnum
  , ItestDmnEnumAllDescr
{
}

public class testDmnEnumAllPrnt
  : GqlpDomainEnum
  , ItestDmnEnumAllPrnt
{
}

public class testDmnEnumDescr
  : GqlpDomainEnum
  , ItestDmnEnumDescr
{
}

public class testDmnEnumExcl
  : GqlpDomainEnum
  , ItestDmnEnumExcl
{
}

public class testDmnEnumExclPrnt
  : GqlpDomainEnum
  , ItestDmnEnumExclPrnt
{
}

public class testDmnEnumLabel
  : GqlpDomainEnum
  , ItestDmnEnumLabel
{
}

public class testDmnEnumPrnt
  : testPrntDmnEnumPrnt
  , ItestDmnEnumPrnt
{
}

public class testPrntDmnEnumPrnt
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrnt
{
}

public class testDmnEnumPrntDescr
  : testPrntDmnEnumPrntDescr
  , ItestDmnEnumPrntDescr
{
}

public class testPrntDmnEnumPrntDescr
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrntDescr
{
}

public class testDmnEnumUnq
  : GqlpDomainEnum
  , ItestDmnEnumUnq
{
}

public class testDmnEnumUnqPrnt
  : GqlpDomainEnum
  , ItestDmnEnumUnqPrnt
{
}

public class testDmnEnumValue
  : GqlpDomainEnum
  , ItestDmnEnumValue
{
}

public class testDmnEnumValuePrnt
  : GqlpDomainEnum
  , ItestDmnEnumValuePrnt
{
}

public class testDmnNmbrDescr
  : GqlpDomainNumber
  , ItestDmnNmbrDescr
{
}

public class testDmnNmbrPrnt
  : testPrntDmnNmbrPrnt
  , ItestDmnNmbrPrnt
{
}

public class testPrntDmnNmbrPrnt
  : GqlpDomainNumber
  , ItestPrntDmnNmbrPrnt
{
}

public class testDmnNmbrPrntDescr
  : testPrntDmnNmbrPrntDescr
  , ItestDmnNmbrPrntDescr
{
}

public class testPrntDmnNmbrPrntDescr
  : GqlpDomainNumber
  , ItestPrntDmnNmbrPrntDescr
{
}

public class testDmnNmbrPstv
  : GqlpDomainNumber
  , ItestDmnNmbrPstv
{
}

public class testDmnNmbrRange
  : GqlpDomainNumber
  , ItestDmnNmbrRange
{
}

public class testDmnStrDescr
  : GqlpDomainString
  , ItestDmnStrDescr
{
}

public class testDmnStrNonEmpty
  : GqlpDomainString
  , ItestDmnStrNonEmpty
{
}

public class testDmnStrPrnt
  : testPrntDmnStrPrnt
  , ItestDmnStrPrnt
{
}

public class testPrntDmnStrPrnt
  : GqlpDomainString
  , ItestPrntDmnStrPrnt
{
}

public class testDmnStrPrntDescr
  : testPrntDmnStrPrntDescr
  , ItestDmnStrPrntDescr
{
}

public class testPrntDmnStrPrntDescr
  : GqlpDomainString
  , ItestPrntDmnStrPrntDescr
{
}

public class testUnionDescr
  : GqlpModelBase
  , ItestUnionDescr
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class testUnionPrnt
  : testPrntUnionPrnt
  , ItestUnionPrnt
{
}

public class testPrntUnionPrnt
  : GqlpModelBase
  , ItestPrntUnionPrnt
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class testUnionPrntDescr
  : testPrntUnionPrntDescr
  , ItestUnionPrntDescr
{
}

public class testPrntUnionPrntDescr
  : GqlpModelBase
  , ItestPrntUnionPrntDescr
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}

public class testUnionPrntDup
  : testPrntUnionPrntDup
  , ItestUnionPrntDup
{
}

public class testPrntUnionPrntDup
  : GqlpModelBase
  , ItestPrntUnionPrntDup
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
