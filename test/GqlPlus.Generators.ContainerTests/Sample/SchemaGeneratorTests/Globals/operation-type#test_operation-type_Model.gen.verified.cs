//HintName: test_operation-type_Model.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_type;

public class testCatOprType
  : GqlpModelBase
  , ItestCatOprType
{
  public ItestCatOprTypeObject? As_CatOprType { get; set; }
}

public class testCatOprTypeObject
  : GqlpModelBase
  , ItestCatOprTypeObject
{
  public string First { get; set; }
  public string Last { get; set; }
  public ItestAddrOprType Address { get; set; }

  public testCatOprTypeObject
    ( string pfirst
    , string plast
    , ItestAddrOprType paddress
    )
  {
    First = pfirst;
    Last = plast;
    Address = paddress;
  }
}

public class testAddrOprType
  : GqlpModelBase
  , ItestAddrOprType
{
  public ItestAddrOprTypeObject? As_AddrOprType { get; set; }
}

public class testAddrOprTypeObject
  : GqlpModelBase
  , ItestAddrOprTypeObject
{
  public string Street { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public testAddrOprTypeObject
    ( string pstreet
    , string pcity
    , string pcountry
    )
  {
    Street = pstreet;
    City = pcity;
    Country = pcountry;
  }
}
