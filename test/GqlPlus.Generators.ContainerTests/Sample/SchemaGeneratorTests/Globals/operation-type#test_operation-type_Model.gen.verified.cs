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
    ( string first
    , string last
    , ItestAddrOprType address
    )
  {
    First = first;
    Last = last;
    Address = address;
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
    ( string street
    , string city
    , string country
    )
  {
    Street = street;
    City = city;
    Country = country;
  }
}
