using HtmlAgilityPack;

namespace LocalEditor
{
	public class TranslatableElement
	{
		public string LineKey { get; }
		public HtmlNode Node { get; }
		public string AttributeName { get; }
		public string Name { get; }
		public string Text
		{
			get
			{
				if (this.Node is HtmlTextNode textNode)
					return textNode.Text;
				else if (this.AttributeName != null)
					return this.Node.GetAttributeValue(this.AttributeName, "");
				else
					return this.Node.InnerHtml;
			}

			set
			{
				if (this.Node is HtmlTextNode textNode)
					textNode.Text = value;
				else if (this.AttributeName != null)
					this.Node.SetAttributeValue(this.AttributeName, value);
				else
					this.Node.InnerHtml = value;
			}
		}

		public TranslatableElement(string lineKey, HtmlNode node, string attributeName)
		{
			this.LineKey = lineKey;
			this.Node = node;
			this.AttributeName = attributeName;
			this.Name = node.Name;

			if (node is HtmlTextNode textNode)
				this.Text = textNode.Text;
			else if (attributeName != null)
				this.Text = node.GetAttributeValue(attributeName, "");
			else
				this.Text = node.InnerHtml;
		}
	}
}
