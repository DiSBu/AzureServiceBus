/* 
Generated with https://xmltocsharp.azurewebsites.net/
 */
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Common.XMLDataParser.Models
{
	[XmlRoot(ElementName = "Session.loginRs")]
	public class SessionLoginRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "sessionID")]
		public string SessionID { get; set; }
		[XmlAttribute(AttributeName = "expiredPassword")]
		public string ExpiredPassword { get; set; }
		[XmlAttribute(AttributeName = "fullName")]
		public string FullName { get; set; }
		[XmlAttribute(AttributeName = "roleBasedSecurity")]
		public string RoleBasedSecurity { get; set; }
		[XmlAttribute(AttributeName = "entityID")]
		public string EntityID { get; set; }
		[XmlAttribute(AttributeName = "userID")]
		public string UserID { get; set; }
		[XmlAttribute(AttributeName = "partyID")]
		public string PartyID { get; set; }
		[XmlAttribute(AttributeName = "consumerID")]
		public string ConsumerID { get; set; }
	}

	[XmlRoot(ElementName = "Session.resumeRs")]
	public class SessionResumeRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "sessionID")]
		public string SessionID { get; set; }
		[XmlAttribute(AttributeName = "roleBasedSecurity")]
		public string RoleBasedSecurity { get; set; }
		[XmlAttribute(AttributeName = "entityID")]
		public string EntityID { get; set; }
	}

	[XmlRoot(ElementName = "OnlineData.loadPolicyRs")]
	public class OnlineDataLoadPolicyRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "manuScriptID")]
		public string ManuScriptID { get; set; }
	}

	[XmlRoot(ElementName = "OnlineData.loadHistoryRs")]
	public class OnlineDataLoadHistoryRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "manuScriptID")]
		public string ManuScriptID { get; set; }
	}

	[XmlRoot(ElementName = "ManuScript.getPageRq")]
	public class ManuScriptGetPageRq
	{

		[XmlAttribute(AttributeName = "command")]
		public string Command { get; set; }

		[XmlAttribute(AttributeName = "annotations")]
		public int Annotations { get; set; }

		[XmlAttribute(AttributeName = "preCommand")]
		public string PreCommand { get; set; }

		[XmlAttribute(AttributeName = "postAction")]
		public string PostAction { get; set; }

		[XmlAttribute(AttributeName = "printJobManuScript")]
		public string PrintJobManuScript { get; set; }

		[XmlAttribute(AttributeName = "printJob")]
		public string PrintJob { get; set; }

		[XmlAttribute(AttributeName = "manuscript")]
		public string Manuscript { get; set; }

		[XmlAttribute(AttributeName = "topic")]
		public string Topic { get; set; }

		[XmlAttribute(AttributeName = "page")]
		public string Page { get; set; }

		[XmlAttribute(AttributeName = "preEventField")]
		public string PreEventField { get; set; }

		[XmlAttribute(AttributeName = "policyNumber")]
		public int PolicyNumber { get; set; }

		[XmlAttribute(AttributeName = "popUpWidth")]
		public int PopUpWidth { get; set; }

		[XmlAttribute(AttributeName = "popUpHeight")]
		public int PopUpHeight { get; set; }

		[XmlAttribute(AttributeName = "ignoreValidation")]
		public int IgnoreValidation { get; set; }

		[XmlAttribute(AttributeName = "popUp")]
		public int PopUp { get; set; }

		[XmlAttribute(AttributeName = "popUpTitle")]
		public string PopUpTitle { get; set; }

		[XmlAttribute(AttributeName = "readOnly")]
		public int ReadOnly { get; set; }

		[XmlAttribute(AttributeName = "usePartyMappings")]
		public int UsePartyMappings { get; set; }

		[XmlAttribute(AttributeName = "calculate")]
		public int Calculate { get; set; }

		[XmlElement(ElementName = "persist")]
		public Persist Persist { get; set; }
	}

	[XmlRoot(ElementName = "Session.resumeRq")]
	public class SessionResumeRq
	{

		[XmlAttribute(AttributeName = "sessionID")]
		public string SessionID { get; set; }
	}

	[XmlRoot(ElementName = "requests")]
	public class Requests
	{

		[XmlElement(ElementName = "Session.resumeRq")]
		public SessionResumeRq SessionResumeRq { get; set; }

		[XmlElement(ElementName = "Session.storeDataRq")]
		public object SessionStoreDataRq { get; set; }

		[XmlElement(ElementName = "ManuScript.getPageRq")]
		public ManuScriptGetPageRq ManuScriptGetPageRq { get; set; }

		[XmlElement(ElementName = "TransACT.checkinRq")]
		public object TransACTCheckinRq { get; set; }

		[XmlElement(ElementName = "Session.beginTransactionRq")]
		public object SessionBeginTransactionRq { get; set; }

		[XmlElement(ElementName = "ManuScript.getValueRq")]
		public ManuScriptGetValueRq ManuScriptGetValueRq { get; set; }

		[XmlElement(ElementName = "ManuScript.getFieldRq")]
		public ManuScriptGetFieldRq ManuScriptGetFieldRq { get; set; }
	}

	[XmlRoot(ElementName = "section")]
	public class Section
	{
		[XmlElement(ElementName = "fieldInstance")]
		public List<FieldInstance> FieldInstance { get; set; }
		[XmlAttribute(AttributeName = "caption")]
		public string Caption { get; set; }
		[XmlAttribute(AttributeName = "direction")]
		public string Direction { get; set; }

		[XmlAttribute(AttributeName = "captionPosition")]
		public string CaptionPosition { get; set; }

		[XmlAttribute(AttributeName = "showCaption")]
		public string ShowCaption { get; set; }

		[XmlAttribute(AttributeName = "class")]
		public string Class { get; set; }

		[XmlAttribute(AttributeName = "index")]
		public string Index { get; set; }

		[XmlAttribute(AttributeName = "uid")]
		public string Uid { get; set; }

		[XmlElement(ElementName = "section")]
		public List<Section> SubSection { get; set; }

		[XmlAttribute(AttributeName = "validRef")]
		public string ValidRef { get; set; }

		[XmlAttribute(AttributeName = "capClass")]
		public string CapClass { get; set; }
	}

	[XmlRoot(ElementName = "caption")]
	public class Caption
	{
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "uid")]
		public string Uid { get; set; }
		[XmlAttribute(AttributeName = "index")]
		public string Index { get; set; }
		[XmlAttribute(AttributeName = "objectRef")]
		public string ObjectRef { get; set; }
		[XmlAttribute(AttributeName = "fieldRef")]
		public string FieldRef { get; set; }
	}

	[XmlRoot(ElementName = "group")]
	public class Group
	{

		[XmlElement(ElementName = "section")]
		public Section Section { get; set; }

		[XmlAttribute(AttributeName = "caption")]
		public string Caption { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "uid")]
		public string Uid { get; set; }
	}

	[XmlRoot(ElementName = "panel")]
	public class Panel
	{

		[XmlElement(ElementName = "group")]
		public Group Group { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "caption")]
		public string Caption { get; set; }

		[XmlAttribute(AttributeName = "manuscript")]
		public string Manuscript { get; set; }

		[XmlAttribute(AttributeName = "pageVersion")]
		public int PageVersion { get; set; }

		[XmlAttribute(AttributeName = "position")]
		public string Position { get; set; }

		[XmlAttribute(AttributeName = "class")]
		public string Class { get; set; }

		[XmlAttribute(AttributeName = "popUp")]
		public int PopUp { get; set; }
	}

	[XmlRoot(ElementName = "fieldInstance")]
	public class FieldInstance
	{

		[XmlAttribute(AttributeName = "fieldRef")]
		public string FieldRef { get; set; }

		[XmlAttribute(AttributeName = "objectRef")]
		public string ObjectRef { get; set; }

		[XmlAttribute(AttributeName = "uid")]
		public string Uid { get; set; }

		[XmlAttribute(AttributeName = "index")]
		public string Index { get; set; }

		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[XmlAttribute(AttributeName = "path")]
		public string Path { get; set; }

		[XmlAttribute(AttributeName = "caption")]
		public string Caption { get; set; }

		[XmlAttribute(AttributeName = "maxLength")]
		public int MaxLength { get; set; }

		[XmlAttribute(AttributeName = "applicable")]
		public int Applicable { get; set; }

		[XmlAttribute(AttributeName = "readOnly")]
		public int ReadOnly { get; set; }

		[XmlAttribute(AttributeName = "required")]
		public int Required { get; set; }

		[XmlAttribute(AttributeName = "annotations")]
		public int Annotations { get; set; }

		[XmlAttribute(AttributeName = "eliminate")]
		public int Eliminate { get; set; }

		[XmlAttribute(AttributeName = "capClass")]
		public string CapClass { get; set; }

		[XmlAttribute(AttributeName = "fldClass")]
		public string FldClass { get; set; }

		[XmlAttribute(AttributeName = "onBlurID")]
		public string OnBlurID { get; set; }

		[XmlAttribute(AttributeName = "formatMask")]
		public string FormatMask { get; set; }

		[XmlAttribute(AttributeName = "maximum")]
		public decimal Maximum { get; set; }

		[XmlAttribute(AttributeName = "minimum")]
		public decimal Minimum { get; set; }

		[XmlAttribute(AttributeName = "class")]
		public string Class { get; set; }

		[XmlAttribute(AttributeName = "comment")]
		public string Comment { get; set; }
	}

	[XmlRoot(ElementName = "ManuScript.getValueRq")]
	public class ManuScriptGetValueRq
	{

		[XmlAttribute(AttributeName = "manuscript")]
		public string Manuscript { get; set; }

		[XmlAttribute(AttributeName = "field")]
		public string Field { get; set; }
	}

	[XmlRoot(ElementName = "body")]
	public class Body
	{

		[XmlElement(ElementName = "group")]
		public Group Group { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "caption")]
		public string Caption { get; set; }

		[XmlAttribute(AttributeName = "manuscript")]
		public string Manuscript { get; set; }

		[XmlAttribute(AttributeName = "pageVersion")]
		public int PageVersion { get; set; }

		[XmlAttribute(AttributeName = "popUp")]
		public int PopUp { get; set; }

		[XmlAttribute(AttributeName = "calculate")]
		public int Calculate { get; set; }

		[XmlAttribute(AttributeName = "conditional")]
		public int Conditional { get; set; }

		[XmlAttribute(AttributeName = "readOnly")]
		public int ReadOnly { get; set; }
	}

	[XmlRoot(ElementName = "ManuScript.getFieldRq")]
	public class ManuScriptGetFieldRq
	{

		[XmlAttribute(AttributeName = "manuscript")]
		public string Manuscript { get; set; }

		[XmlAttribute(AttributeName = "fieldID")]
		public string FieldID { get; set; }
	}

	[XmlRoot(ElementName = "persist")]
	public class Persist
	{

		[XmlAttribute(AttributeName = "manuscript")]
		public string Manuscript { get; set; }

		[XmlAttribute(AttributeName = "topic")]
		public string Topic { get; set; }
	}

	[XmlRoot(ElementName = "getPage")]
	public class GetPage
	{

		[XmlElement(ElementName = "panel")]
		public List<Panel> Panel { get; set; }

		[XmlElement(ElementName = "body")]
		public Body Body { get; set; }

		[XmlAttribute(AttributeName = "topic")]
		public string Topic { get; set; }

		[XmlAttribute(AttributeName = "page")]
		public string Page { get; set; }
	}

	[XmlRoot(ElementName = "ManuScript.getPageRs")]
	public class ManuScriptGetPageRs
	{

		[XmlElement(ElementName = "getPage")]
		public GetPage GetPage { get; set; }

		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
	}

	[XmlRoot(ElementName = "TransACT.startTransactionRs")]
	public class TransACTStartTransactionRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "valid")]
		public string Valid { get; set; }
		[XmlAttribute(AttributeName = "transactionId")]
		public string TransactionId { get; set; }
	}

	[XmlRoot(ElementName = "Session.closeRs")]
	public class SessionCloseRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
	}

	[XmlRoot(ElementName = "TransACT.abortTransactionRs")]
	public class TransACTAbortTransactionRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "valid")]
		public string Valid { get; set; }
	}

	[XmlRoot(ElementName = "PartyObj.correctPartyLocationRs")]
	public class PartyObjCorrectPartyLocationRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
	}

	[XmlRoot(ElementName = "PartyObj.addPartyLocationRs")]
	public class PartyObjAddPartyLocationRs
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
	}

	[XmlRoot(ElementName = "ManuScript.getValueRs")]
	public class ManuScriptGetValueRs 
	{
		[XmlAttribute(AttributeName = "status")]
		public string Status { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}
	
	[XmlRoot(ElementName = "responses")]
	public class Responses
	{
		[XmlElement(ElementName = "Session.loginRs")]
		public SessionLoginRs SessionLoginRs { get; set; }
		[XmlElement(ElementName = "Session.resumeRs")]
		public SessionResumeRs SessionResumeRs { get; set; }
		[XmlElement(ElementName = "OnlineData.loadPolicyRs")]
		public OnlineDataLoadPolicyRs OnlineDataLoadPolicyRs { get; set; }
		[XmlElement(ElementName = "TransACT.startTransactionRs")]
		public TransACTStartTransactionRs TransACTStartTransactionRs { get; set; }
		[XmlElement(ElementName = "Session.closeRs")]
		public SessionCloseRs SessionCloseRs { get; set; }
		[XmlElement(ElementName = "OnlineData.loadHistoryRs")]
		public OnlineDataLoadHistoryRs OnlineDataLoadHistoryRs { get; set; }
		[XmlElement(ElementName = "ManuScript.getPageRs")]
		public ManuScriptGetPageRs ManuScriptGetPageRs { get; set; }
		[XmlElement(ElementName = "ManuScript.getValueRs")]
		public ManuScriptGetValueRs ManuScriptGetValueRs { get; set; }
		[XmlElement(ElementName = "TransACT.abortTransactionRs")]
		public TransACTAbortTransactionRs TransACTAbortTransactionRs { get; set; }
		[XmlElement(ElementName = "PartyObj.correctPartyLocationRs")]
		public PartyObjCorrectPartyLocationRs PartyObjCorrectPartyLocationRs { get; set; }
		[XmlElement(ElementName = "PartyObj.addPartyLocationRs")]
		public PartyObjAddPartyLocationRs PartyObjAddPartyLocationRs { get; set; }
	}

	[XmlRoot(ElementName = "server")]
	public class CreateEndorsementResponse
	{
		[XmlElement(ElementName = "responses")]
		public Responses Responses { get; set; }

		[XmlElement(ElementName = "requests")]
		public Requests Requests { get; set; }
	}
}