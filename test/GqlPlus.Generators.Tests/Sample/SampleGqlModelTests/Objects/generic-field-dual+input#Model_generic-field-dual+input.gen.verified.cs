//HintName: Model_generic-field-dual+input.gen.cs
// Generated from generic-field-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_input;

public interface IInpGnrcFieldDual
{
  RefInpGnrcFieldDual < I@053/0001 AltInpGnrcFieldDual > field { get; }
}
public class InputInpGnrcFieldDual
{
  public RefInpGnrcFieldDual < I@053/0001 AltInpGnrcFieldDual > field { get; set; }
}

public interface IRefInpGnrcFieldDual
{
  $ref Asref { get; }
}
public class InputRefInpGnrcFieldDual
{
  public $ref Asref { get; set; }
}

public interface IAltInpGnrcFieldDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcFieldDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
