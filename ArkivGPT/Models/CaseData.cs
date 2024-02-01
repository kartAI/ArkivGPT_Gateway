namespace ArkivGPT;

public class CaseData
{
    public CaseData(){}

    public CaseData(List<SummaryElement> summary, PropertyInfo propertyInfo)
    {
        Summary = summary;
        PropertyInfo = propertyInfo;
    }
    public PropertyInfo PropertyInfo { get; set; }
    
    public List<SummaryElement> Summary { get; set; }
}