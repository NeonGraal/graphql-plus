//HintName: Model_generic-field-param+dual.gen.cs
// Generated from generic-field-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_dual;

public interface IDualGnrcFieldParam
{
  RefDualGnrcFieldParam < I@056/0001 AltDualGnrcFieldParam > field { get; }
}
public class DualDualGnrcFieldParam
{
  public RefDualGnrcFieldParam < I@056/0001 AltDualGnrcFieldParam > field { get; set; }
}

public interface IRefDualGnrcFieldParam
{
  $ref Asref { get; }
}
public class DualRefDualGnrcFieldParam
{
  public $ref Asref { get; set; }
}

public interface IAltDualGnrcFieldParam
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcFieldParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
