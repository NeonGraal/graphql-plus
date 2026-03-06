//HintName: test_operation-type_Model.gen.cs
// Generated from {CurrentDirectory}operation-type.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_type;

public class testCatOprType
  : GqlpModelImplementationBase
  , ItestCatOprType
{
  public ItestCatOprTypeObject? As_CatOprType { get; set; }
}

public class testCatOprTypeObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestAddrOprType
{
  public ItestAddrOprTypeObject? As_AddrOprType { get; set; }
}

public class testAddrOprTypeObject
  : GqlpModelImplementationBase
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
